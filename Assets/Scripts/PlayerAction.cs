using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float rotationSpeed = 0.15f;
    public float runSpeed = 4f;
    public float jumpForce = 5f;
    

    private float turnInput;
    private bool isGrounded;
    private bool jumpRequested;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Animator animator;
    private PlayerControls controls;
    private static readonly int State = Animator.StringToHash("State");
    private static readonly int Jump = Animator.StringToHash("Jump");


    private enum PlayerState
    {
        Idle = 0,
        Walk = 1,
        // the run speed.
        Run = 2
    }

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        controls = new PlayerControls();
        isGrounded = true;
        jumpRequested = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
        float rayDistance = 1.8f;

        if (Physics.Raycast(transform.position, Vector3.down, out var hit, rayDistance))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                isGrounded = true;
            }    
                
        }


        if (controls.Player.Jump.triggered && isGrounded)
        {
            jumpRequested = true;
        }    
    }

    void FixedUpdate()
    {
        
        
        

        if (Mathf.Abs(turnInput) > 0.01f) 
        {
            float senitivity = 10f;
            float rotation = turnInput * rotationSpeed * senitivity * Time.deltaTime;


            Quaternion newRotation = rb.rotation * Quaternion.Euler(0, rotation, 0);
            rb.MoveRotation(newRotation); 
        }



        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        moveInput = new Vector3(input.x, y: 0f, z: input.y);
        turnInput = controls.Player.turn.ReadValue<Vector2>().x;

        // checks if the left shift button is press, then it sets the bool isRunning to true. 
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
            
        //if isRunning is true then it makes it move at the speed of the varaible run  
        if (isRunning == true)
        {
            rb.MovePosition(rb.position + moveInput * (runSpeed * Time.deltaTime));
        }
        
        
        
        
        rb.MovePosition(rb.position + moveInput * (walkSpeed * Time.deltaTime));


        if (moveInput.magnitude >= 0.1f)
        {

            Quaternion newRotation = Quaternion.LookRotation(moveInput, Vector3.up);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed);

            


            // sets the animation to the running animation.
            if (isRunning == true)
            {
                SetAnimationState((PlayerState.Run));

            }
            else
            {
                SetAnimationState(PlayerState.Walk);
            }
            // says in the console if the variable isRunning is true or false.
            Debug.Log(isRunning);
        }   
        
        
        
        else
        {
            SetAnimationState(PlayerState.Idle);
        }

        if (jumpRequested && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger(Jump);
            isGrounded = false;
            jumpRequested = false;

        }    
    }
    

    private void SetAnimationState(PlayerState animState)
        {
            animator.SetInteger(State, (int) animState);
        
        }


        private void OnEnable()
        {
            controls.Enable();
        }


        private void OnDisable()
        {
            controls.Disable();
        
        }


        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }    
            
        }
    
}



