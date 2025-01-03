using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera; //references the camera for looking around
    public float walkSpeed = 6f; //speed of walk
    public float runSpeed = 12f; //speed of run
    public float def_walk_speed, def_run_speed; // Default speeds

    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 5f;
    public float lookXLimit = 45f; //maximum vertical rotation to prevent looking too far up/down
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0; //tracks vertical rotation looking up/down
    private CharacterController characterController;

    private bool canMove = true;  // determines if character can move
    private PauseMenu pauseMenu;  // Reference to PauseMenu - Rares changed this

    Animator animator;

    bool isWalking = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>(); //gets charactercontroller component
        Cursor.lockState = CursorLockMode.Locked; //hides the cursor
        Cursor.visible = false; //sets to false

        def_walk_speed = walkSpeed; // stores default walk speed
        def_run_speed = runSpeed; //stores default walk and run speed to reset later

        // Find the PauseMenu script in the scene - Rares changed this
        pauseMenu = FindObjectOfType<PauseMenu>();  // Rares changed this
        animator = GetComponent<Animator>();
    }

    void Update() //update function runs every frame and handles the players movements
    {
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w");

        // Check if the player is pressing the "W" key
        if (forwardPressed && !isWalking)
        {
            animator.SetBool("isWalking", true); // Trigger Walk animation
        }

        // Check if the player is pressing the "W" key
        if (!forwardPressed && isWalking)
        {
            animator.SetBool("isWalking", false); // Trigger Walk animation
        }

        // Check if the game is paused, and disable movement if so - Rares changed this
        if (pauseMenu != null && pauseMenu.isPaused)  // Rares changed this
        {
            canMove = false;  // Disable movement when paused - Rares changed this
            return;  // Exit the update loop to stop further input - Rares changed this
        }
        else
        {
            canMove = true;  // Re-enable movement if not paused - Rares changed this
        }

        // calculates movement direction based on players forward and right vectores
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift); //checks if character is running by hold left shift key
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;  // Rares changed this
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;  // Rares changed this
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)  // Rares changed this
        {
            moveDirection.y = jumpPower; //if character is grounded and presses space bar to jump, the movement direction is set to jumpPower
        }
        else if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime; //if not jumping then keep vertical movement
        }

        if (Input.GetKey(KeyCode.LeftControl) && canMove)  // Rares changed this
        {
            characterController.height = crouchHeight; //reduces crouch height
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed; //both walk and run are set to crouch speed
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = def_walk_speed;
            runSpeed = def_run_speed;
        }

        characterController.Move(moveDirection * Time.deltaTime); //movement application

        if (canMove)  // Rares changed this
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); //prevevnts player from looking too far up and too far down
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}