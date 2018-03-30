using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MouseMono
{

    protected override void Update()
    {
        base.Update();

        // Points the gun towards the mouse.
        PointGun();
    }

    private void PointGun()
    {
        // Transform the direction into an angle and update it.
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        // Rotate the gun based on the current flipped side.
        if (mouseDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }

        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
        }

    }
}
