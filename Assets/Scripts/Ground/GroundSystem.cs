using UnityEngine;

public class GroundSystem
{
    private const float minSpeed = 1.0f;
    private const float timeBeforeMaxSpeed = 120.0f;
    
    private Transform groundParent;
    private float maxSpeed;
    private float padding;
    private float timeRunning;
    private bool createItems;
    
    public GroundSystem(string parentName, float maxSpeedToHit, bool createVeg, float paddingForReset)
    {
        groundParent = GameObject.Find(parentName).transform;
        maxSpeed = maxSpeedToHit;
        createItems = createVeg;
        padding = paddingForReset;
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
                if (createItems)
                {
                    Item.CreateItemObject(child);
                }

                float maxX = 0f;
                for (int j = 0; j < groundParent.childCount; ++j)
                {
                    if (i == j) continue;
                    
                    const int lastSoilChildIndex = 9;
                    const int lastHillIndex = 2;
                    maxX = Mathf.Max(maxX, groundParent.GetChild(j)
                        .GetChild(createItems ? lastSoilChildIndex : lastHillIndex).position.x);
                }

                child.position = new Vector3(maxX + padding, child.position.y, child.position.z);
            }
        }
    }
}
