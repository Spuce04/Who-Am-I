using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float sensitivity = 500f;

    private Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    void Update()
    {
        HandleRotation();
    }

    private void HandleRotation() // rotates the player and camera based on how far the mouse moves
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        // gets mouse position changes

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// stops the camera from rotating more than straight up and straight down

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//rotates the camera up and down
        playerBody.Rotate(Vector3.up * mouseX);// rotates the player left and right
    }
}