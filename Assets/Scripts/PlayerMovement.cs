using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float def_walk_speed, def_run_speed; // Default speeds

    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 5f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;  // To control movement
    private PauseMenu pauseMenu;  // Reference to PauseMenu - Rares changed this

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        def_walk_speed = walkSpeed; // Save default speeds
        def_run_speed = runSpeed;

        // Find the PauseMenu script in the scene - Rares changed this
        pauseMenu = FindObjectOfType<PauseMenu>();  // Rares changed this
    }

    void Update()
    {
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

        // Movement and camera rotation code (only works if canMove is true)
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;  // Rares changed this
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;  // Rares changed this
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)  // Rares changed this
        {
            moveDirection.y = jumpPower;
        }
        else if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl) && canMove)  // Rares changed this
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

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)  // Rares changed this
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}