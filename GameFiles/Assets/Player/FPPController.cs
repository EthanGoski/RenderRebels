using UnityEngine;

public class FPPController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraHolder;

    private CharacterController controller;
    private float verticalRotation = 0f;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Hide & lock cursor
        Cursor.visible = false;
    }

    void Update()
    {
        // 1️⃣ Handle Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraHolder.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // 2️⃣ Handle Movement (WASD)
        float moveX = Input.GetAxis("Horizontal");  // A/D keys
        float moveZ = Input.GetAxis("Vertical");    // W/S keys

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
