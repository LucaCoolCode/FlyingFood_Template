using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private Transform playerCamera;

    // Movement settings
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float friction = 6.0f;
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float airAcceleration = 15.0f;
    [SerializeField] private float maxAirSpeed = 20.0f;

    // Mouse settings
    [SerializeField] private float mouseSensitivity = 3.0f;
    private float rotationX = 0.0f;

    // Trimp settings
    [SerializeField] private float trimpSlopeThreshold = 30f; // in degrees
    [SerializeField] private float trimpBoostMultiplier = 0.4f;
    [SerializeField] private float trimpForwardBoostMultiplier = 0.5f; // NEW: forward trimp boost multiplier
    private Vector3 lastGroundNormal = Vector3.up;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 wishDir;
    private float wishSpeed;

    private bool isGrounded;

    public void AddExplosionForce(Vector3 explosionOrigin, float force)
    {
        Vector3 explosionDirection = (transform.position - explosionOrigin).normalized;
        moveDirection += explosionDirection * force;
    }


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 + 0.5f))
            {
                lastGroundNormal = hit.normal;
            }
        }

        MouseLook();

        if (isGrounded)
        {
            GroundMove();
        }
        else
        {
            AirMove();
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void GroundMove()
    {
        moveDirection.x *= 1 - (friction * Time.deltaTime);
        moveDirection.z *= 1 - (friction * Time.deltaTime);

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        wishDir = new Vector3(moveX, 0, moveZ);
        wishDir = transform.TransformDirection(wishDir);
        wishDir.Normalize();
        wishSpeed = wishDir.magnitude * moveSpeed;

        moveDirection = Accelerate(moveDirection, wishDir, wishSpeed, acceleration);
        float slopeAngle = Vector3.Angle(lastGroundNormal, Vector3.up);

        if (Input.GetButton("Jump"))
        {
            float trimpBoost = 0f;
            float angleBoost = 0f;

            if (slopeAngle > trimpSlopeThreshold)
            {
                Vector3 horizontalVelocity = new Vector3(moveDirection.x, 0, moveDirection.z);
                trimpBoost = horizontalVelocity.magnitude * trimpBoostMultiplier;
                angleBoost = Mathf.Max(45 - Mathf.Abs(slopeAngle - 45), 0);

                // Apply forward trimp boost
                Vector3 forwardDir = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
                moveDirection += forwardDir * trimpBoost * trimpForwardBoostMultiplier;
            }

            moveDirection.y = jumpSpeed + trimpBoost * angleBoost;
        }
    }

    void AirMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        wishDir = new Vector3(moveX, 0, moveZ);
        wishDir = transform.TransformDirection(wishDir);
        wishDir.Normalize();
        wishSpeed = wishDir.magnitude * moveSpeed;

        moveDirection = Accelerate(moveDirection, wishDir, wishSpeed, airAcceleration);
    }

    Vector3 Accelerate(Vector3 velocity, Vector3 wishDir, float wishSpeed, float accel)
    {
        float currentSpeed = Vector3.Dot(velocity, wishDir);
        float addSpeed = wishSpeed - currentSpeed;
        if (addSpeed > 0)
        {
            float accelSpeed = accel * Time.deltaTime * wishSpeed;
            velocity += wishDir * Mathf.Min(addSpeed, accelSpeed);
        }

        if (!isGrounded && velocity.magnitude > maxAirSpeed)
        {
            velocity = velocity.normalized * maxAirSpeed;
        }

        return velocity;
    }
}
