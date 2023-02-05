using System;
using UnityEngine;

public class InputSystem
{
    private Vector3? previousTouchPos;
    private Rigidbody interactionBody;
    private Camera camera;
    private GameUI gameUI;

    public InputSystem(GameUI gameUIState)
    {
        camera = Camera.main;
        gameUI = gameUIState;
    }

    public void UpdateTouch(float dt)
    {
        if (Input.GetMouseButton(0))
        {
            TouchDown(dt);
        }
        else
        {
            TouchUp();
        }
    }

    private void TouchDown(float dt)
    {
#if UNITY_EDITOR
        var inputPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z);
#else
        var inputPosition = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, -camera.transform.position.z);
#endif
        
        var touchWorldPos = camera.ScreenToWorldPoint(inputPosition);

        if (interactionBody != null)
        {
            interactionBody.position = new Vector3(touchWorldPos.x, touchWorldPos.y, interactionBody.position.z);
            gameUI.SetBumperAlphaValues(interactionBody.position);
            if (interactionBody.gameObject.layer != LayerMask.NameToLayer("InteractedWith"))
            {
                interactionBody.gameObject.layer = LayerMask.NameToLayer("InteractedWith");
            }
        }
        else
        {
            var touchRay = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(touchRay, out RaycastHit hit))
            {
                interactionBody = hit.transform.GetComponent<Rigidbody>();
                if (interactionBody != null)
                {
                    interactionBody.transform.parent = null;
                }
            }
        }

        if (interactionBody != null && previousTouchPos.HasValue)
        {
            const float threshold = 0.02f;
            interactionBody.velocity = (touchWorldPos - previousTouchPos.Value).magnitude > threshold ? (touchWorldPos - previousTouchPos.Value) * 10 : Vector3.zero;
        }

        previousTouchPos = touchWorldPos;
    }

    // Can't believe this is the name I choose to go with.
    // Disgusting.
    private void TouchUp()
    {
        if (interactionBody != null)
        {
            interactionBody.useGravity = true;
            
            previousTouchPos = null;
            interactionBody = null;
        }
        
        gameUI.ResetBumperAlphaValues();
    }
}
