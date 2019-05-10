using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float gravity = -12;
    public float jumpHeight = 1;
    [Range(0, 1)]
    public float airControlPercent;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    public Transform cameraT;
    public Transform cameraParentT;
    // Animator animator;
    CharacterController controller;
    
    void Start()
    {
        //animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool running = Input.GetKey(KeyCode.LeftShift);

        BodyRotate();
        Move(horizontalInput, verticalInput, running);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        } 

        // animator
    }

    void BodyRotate()
    {
        float targetRotation = cameraT.eulerAngles.y;
        transform.eulerAngles = Vector3.up * targetRotation;
    }

    void Move(float horizontalInput, float verticalInput, bool running)
    {
        float targetSpeed = (running) ? runSpeed : walkSpeed;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

       
        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = (forwardMovement + rightMovement).normalized * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        cameraParentT.position = transform.position;
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }

    float GetModifiedSmoothTime(float smoothTime)
    {
        if (controller.isGrounded)
        {
            return smoothTime;
        }

        if(airControlPercent == 0)
        {
            return float.MaxValue;
        }

        return smoothTime / airControlPercent;
    }
}
