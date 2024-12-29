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
    private PauseMenu pauseMenu;  // Reference to PauseMenu

    void Start()
    {
        characterController = GetComponent<CharacterController>(); //gets charactercontroller component
        Cursor.lockState = CursorLockMode.Locked; //hides the cursor
        Cursor.visible = false; //sets to false

        def_walk_speed = walkSpeed; // stores default walk speed
        def_run_speed = runSpeed; //stores default walk and run speed to reset later

        // Find the PauseMenu script in the scene
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    void Update() //update function runs every frame and handles the players movements
    {
        // Check if the game is paused, and disable movement if so
        if (pauseMenu != null && pauseMenu.isPaused)
        {
            canMove = false;
            return;
        }
        else
        {
            canMove = true;
        }

        // calculates movement direction based on players forward and right vectors
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = def_walk_speed;
            runSpeed = def_run_speed;
        }

        // Apply movement
        if (canMove)
        {
            characterController.Move(moveDirection * Time.deltaTime);
        }

        // Handle rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    // New method to handle teleportation
    public void Teleport(Vector3 destination)
    {
        canMove = false; // Temporarily disable movement
        characterController.enabled = false; // Disable CharacterController to prevent interference
        transform.position = destination; // Update position
        characterController.enabled = true; // Re-enable CharacterController
        canMove = true; // Re-enable movement
        Debug.Log($"Player teleported to {destination}");
    }
}
