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
                Item.CreateItemObject(child);
                float maxX = 0f;
                for (int j = 0; j < groundParent.childCount; ++j)
                {
                    if (i == j) continue;
                    
                    const int lastSoilChildIndex = 9;
                    maxX = Mathf.Max(maxX, groundParent.GetChild(j)
                        .GetChild(lastSoilChildIndex).position.x);
                }

                const float padding = 15f;
                child.position = new Vector3(maxX + padding, child.position.y, child.position.z);
            }
        }
    }
}
