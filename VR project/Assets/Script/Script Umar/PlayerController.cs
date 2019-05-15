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
    public Vector3 cameraOffset = Vector3.zero;
    Transform headPosition;

    Animator animator;
    CharacterController controller;
    

    bool isForward = false;
    bool isSide = false;
    bool isJumping = false;
    bool isPushing = false;

    bool pushTrigger = false;
    bool buttonTrigger = false;
    Vector3 triggerPosition = Vector3.zero;
    bool isInteracting = false;
    bool isLanding = false;

    public float dampingTime = 0.15f;

    void Start()
    {
        //cameraOffset = cameraParentT.position;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool running = Input.GetKey(KeyCode.LeftShift);

        BodyRotate();

        Move(horizontalInput, verticalInput, running);

        CameraFollow();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Submit"))
        {
            if (pushTrigger)
            {

            }
            else if (buttonTrigger)
            {
                ButtonInteraction();
            }
        }

        CheckAnimationFinished();

        // animator
        MovementAnimation(horizontalInput, verticalInput, running);
    }

    void MovementAnimation(float horizontalInput, float verticalInput, bool running)
    {
        if (Mathf.Abs(verticalInput) == 0 && Mathf.Abs(horizontalInput) > 0)
        {
            isForward = false;
            isSide = true;
        }
        else if (Mathf.Abs(verticalInput) > 0)
        {
            isForward = true;
            isSide = false;
        }

        animator.SetBool("isForward", isForward);
        animator.SetBool("isSide", isSide);

        float speedPercent = 0f;

        if (isForward)
        {
            speedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f) * verticalInput;
        }

        if (isSide)
        {
            speedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f) * horizontalInput;
        }

        animator.SetFloat("speedPercent", speedPercent, dampingTime, Time.deltaTime);

        if (speedPercent <= 0)
        {
            isForward = false;
            isSide = false;
        }
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

        if (isLanding || isInteracting)
        {
            velocity = Vector3.zero;
        }

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }
        
    }

    void CameraFollow()
    {
        headPosition = animator.GetBoneTransform(HumanBodyBones.Head);
        //cameraParentT.position = transform.position + cameraOffset;
        cameraParentT.position = headPosition.position + cameraOffset;
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
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

    public void SetPushTrigger(bool trigger)
    {
        pushTrigger = trigger;
    }

    public void SetButtonTrigger(bool trigger)
    {
        buttonTrigger = trigger;
    }

    public void SetTriggerPosition (Vector3 position)
    {
        triggerPosition = position;
    }

    void ButtonInteraction ()
    {
        isInteracting = true;
        transform.position = triggerPosition;
        animator.SetTrigger("buttonPressing");
    }

    void CheckAnimationFinished ()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
        {
            isLanding = true;
        }
        else
        {
            isLanding = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ButtonPress"))
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }
    }
}
