using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other); // Pass the colliding object
        }
    }

    public void Collect(Collider player)
    {
        // Play collect sound if assigned
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

        // Instantiate collect effect if assigned
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);

        // Call DiamondCollected() from PlayerInventory
        PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();
        }

        // Destroy the diamond object
        Destroy(gameObject);
    }
}
