using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed; // Speed at which the ground rotates
    public float maxRotation; // Maximum tilt angle in degrees
    public GameObject ground;

    private bool gyroEnabled;
    private float mouseX, mouseY;

    void Start()
    {
        // Enable the gyroscope if supported
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            gyroEnabled = true;
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device. Falling back to mouse controls.");
            gyroEnabled = false;
        }
    }

    void FixedUpdate()
    {
        if (gyroEnabled)
        {
            RotateMazeWithGyro();
        }
        else if (Input.GetMouseButton(0)) // Fallback to mouse controls
        {
            RotateMazeWithMouse();
        }
    }

    void RotateMazeWithGyro()
    {
        // Get the gyroscope's rotation data
        Vector3 rotation = Input.gyro.gravity;

        // Calculate rotation angles based on gyroscope input
        float rotateX = rotation.x * maxRotation;
        float rotateZ = rotation.y * maxRotation;

        // Clamp the rotation values to the specified range
        rotateX = Mathf.Clamp(rotateX, -maxRotation, maxRotation);
        rotateZ = Mathf.Clamp(rotateZ, -maxRotation, maxRotation);

        // Apply the rotation to the ground
        transform.rotation = Quaternion.Euler(rotateZ, 0, -rotateX);
    }

    void RotateMazeWithMouse()
    {
        // Accumulate mouse movement
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotateSpeed;

        // Clamp the rotation values to the specified range
        mouseX = Mathf.Clamp(mouseX, -maxRotation, maxRotation);
        mouseY = Mathf.Clamp(mouseY, -maxRotation, maxRotation);

        // Apply the rotation to the ground
        transform.rotation = Quaternion.Euler(mouseY, 0, -mouseX);
    }
}