using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction vector in local space.
        Vector3 direction = mousePosition - transform.parent.position;

        // Calculate the angle in degrees.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a quaternion rotation using the calculated angle.
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Apply the rotation to the GameObject's local rotation.
        transform.rotation = rotation;

        Debug.Log(rotation);
    }
}
