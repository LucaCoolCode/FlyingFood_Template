using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    // Movement Speeds
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float friction = 0.5f; // Lower friction = smoother movement
    [SerializeField] private float airAcceleration = 15.0f; // Faster air strafing

    // Mouse Sensitivity
    [SerializeField] private float mouseSensitivity = 2.5f;

    private Vector3 velocity;
    private bool isGrounded;
    private bool jumpQueued;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookAround();
        HandleMovement();
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Apply vertical look (camera pitch) here (if desired):
        Camera.main.transform.Rotate(Vector3.left * mouseY);
    }

    void HandleMovement()
    {
        isGrounded = controller.isGrounded;

        // Get input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = transform.right * moveX + transform.forward * moveZ;
        moveDir = moveDir.normalized;

        if (isGrounded)
        {
            GroundMove(moveDir);
            if (Input.GetKeyDown(KeyCode.Space)) jumpQueued = true;
        }
        else
        {
            AirMove(moveDir);
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Apply movement
        controller.Move(velocity * Time.deltaTime);
    }

    void GroundMove(Vector3 moveDir)
    {
        // Apply friction
        velocity.x *= 1 - (friction * Time.deltaTime);
        velocity.z *= 1 - (friction * Time.deltaTime);

        // Apply movement
        velocity.x = moveDir.x * moveSpeed;
        velocity.z = moveDir.z * moveSpeed;

        // Auto Bunny Hop
        if (jumpQueued)
        {
            velocity.y = jumpForce;
            jumpQueued = false;
        }
    }

    void AirMove(Vector3 moveDir)
    {
        // Apply air acceleration for smooth strafing
        velocity.x = Accelerate(velocity.x, moveDir.x, moveSpeed, airAcceleration);
        velocity.z = Accelerate(velocity.z, moveDir.z, moveSpeed, airAcceleration);
    }

    float Accelerate(float currentSpeed, float wishDir, float maxSpeed, float acceleration)
    {
        float addSpeed = maxSpeed - Mathf.Abs(currentSpeed);
        if (addSpeed <= 0) return currentSpeed;
        float accelSpeed = Mathf.Min(acceleration * Time.deltaTime, addSpeed);
        return currentSpeed + wishDir * accelSpeed;
    }
}