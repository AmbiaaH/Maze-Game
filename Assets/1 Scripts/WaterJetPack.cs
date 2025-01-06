using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterJetPack : MonoBehaviour
{
    public GameObject jetPack;
    public CharacterController characterController;
    //public AnimationScript animationScript;
    public float liftHeight = 100f;
    public float liftSpeed = 50f;
    public float fallSpeed = 30f;

    private PlayerMovement playerMovement;
    private bool isLifting = false;
    private bool isFalling = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        jetPack.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!isLifting && !isFalling)
            {
                Debug.Log("Start lift");
                StartLift();
                jetPack.SetActive(true);
            }
        }

        if (isLifting)
        {
            LiftPlayer();
        }

        if (isFalling)
        {
            FallPlayer();
        }
    }


    void StartLift()
    {
        isLifting = true;
        initialPosition = transform.position;
        playerMovement.enabled = false;
        characterController.enabled = false;
        //animationScript.enabled = false;
    }


    void LiftPlayer()
    {
        Debug.Log("Lift player");
        if (transform.position.y < liftHeight)
        {
            Debug.Log("lets Lift: " + transform.position);
            transform.position += new Vector3(0, liftSpeed * Time.deltaTime, 0);
        }
        else
        {

            transform.position = new Vector3(initialPosition.x, liftHeight, initialPosition.z);
            Invoke("StartFalling", 0.5f);
        }
    }


    void StartFalling()
    {
        isFalling = true;
        isLifting = false;
        jetPack.SetActive(false);
    }


    void FallPlayer()
    {
        Debug.Log("Current Position: " + transform.position.y);
        Debug.Log("Initial Position: " + initialPosition.y);


        if (transform.position.y > initialPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, fallSpeed * Time.deltaTime);
        }
        else
        {

            Debug.Log("Player has reached the ground.");
            isFalling = false;
            playerMovement.enabled = true;
            characterController.enabled = true;
            //animationScript.enabled = false;
        }
    }
}