using UnityEngine;

//I got this script entirely from CoPilot

public class CameraController : MonoBehaviour
{
    public Transform target; // The player or target to follow
    public float lockX = 0f; // The x-value to lock the camera to
    public float lockY = 0f; // The y-value to lock the camera to
    public bool lockXAxis = true; // Lock the x-axis
    public bool lockYAxis = false; // Lock the y-axis
    public float smoothTime; // Smoothing time for following

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()//Late update is like update except it is called after Update is called
    {
        Vector3 targetPosition = transform.position;

        // Update the camera's position
        if (!lockXAxis)
        {
            targetPosition.x = Mathf.Lerp(transform.position.x, target.position.x + lockX, 1f);
        }
        else
        {
            targetPosition.x = lockX;
        }

        if (!lockYAxis)
        {
            targetPosition.y = Mathf.Lerp(transform.position.y, target.position.y + lockY, 1f);
        }
        else
        {
            targetPosition.y = lockY;
        }

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
