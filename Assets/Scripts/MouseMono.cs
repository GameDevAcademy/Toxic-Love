using UnityEngine;

public class MouseMono : MonoBehaviour
{
    protected Vector3 mousePosition;
    protected Vector3 mouseDirection;

	// Update is called once per frame
	protected virtual void Update ()
    {
        // Update the mouse direction based on the mouse and current point.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = mousePosition - transform.position;
    }
}
