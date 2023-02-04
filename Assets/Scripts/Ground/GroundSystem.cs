using UnityEngine;

public class GroundSystem
{
    private const float minSpeed = 0.1f;
    private const float maxSpeed = 30.0f;
    private const float timeBeforeMaxSpeed = 60.0f;
    
    private Transform groundParent;
    private float timeRunning;
    
    public GroundSystem()
    {
        groundParent = GameObject.Find("GroundParent").transform;
    }

    public void UpdateMovement(float dt)
    {
        timeRunning += dt;
        float speed = Mathf.Lerp(minSpeed, maxSpeed, timeRunning / timeBeforeMaxSpeed);

        for (int i = 0; i < groundParent.childCount; ++i)
        {
            var child = groundParent.GetChild(i);
            var pos = child.position;
            child.position = new Vector3(pos.x - (speed * dt), pos.y, pos.z);

            if (child.position.x < -50.0f)
            {
                float maxX = 0f;
                for (int j = 0; j < groundParent.childCount; ++j)
                {
                    if (i == j) continue;

                    maxX = Mathf.Max(maxX, groundParent.GetChild(j).position.x);
                }

                const float planeScale = 10.0f;
                child.position = new Vector3(maxX + (child.lossyScale.x * planeScale) - 1.0f, child.position.y, child.position.z);
                
                //TODO: Remove existent roots.
                //TODO: Re-add root images.
            }
        }
    }
}
