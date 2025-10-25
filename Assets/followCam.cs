using UnityEngine;

// This class ensures that the camera follows the player horizontally
public class CameraFollow : MonoBehaviour
{
    // The target (player) that the camera follows
    public Transform target;
    // The distance between the camera and the player
    public Vector3 dist;

    void LateUpdate()
    {
        // Check if the target is not null before accessing its position
        if (target != null)
        {
            // Set the X position of the camera to the target's X position plus the offset
            float posX = target.position.x + dist.x;
            // Keep the current Y and Z positions of the camera
            float posY = transform.position.y;
            float posZ = transform.position.z;

            // Create a new vector for the desired camera position
            Vector3 desiredPosition = new Vector3(posX, posY, posZ);

            // Smoothly move the camera to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
            transform.position = smoothedPosition;
        }
        else
        {
            // Log a warning if the target has been destroyed
            Debug.LogWarning("Target has been destroyed or is not assigned.");
        }
    }
}



