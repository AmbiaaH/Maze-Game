using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
    }
}
