using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportEnd;
    public float teleportationHeightOffset = 1.0f;
    public AudioSource teleportSound;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter fired for {other.name}");

        if (other.CompareTag("Player"))
        {
            if (teleportEnd != null)
            {
                Vector3 newPosition = teleportEnd.position + new Vector3(0, teleportationHeightOffset, 0);

                Debug.Log($"Teleport destination: {newPosition}");

                // Get the PlayerMovement script and call the Teleport method
                PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.Teleport(newPosition);
                }
                else
                {
                    Debug.LogError("PlayerMovement script not found on Player");
                }

                // Play teleport sound if assigned
                if (teleportSound != null)
                {
                    teleportSound.Play();
                }
            }
            else
            {
                Debug.LogError("TeleportEnd object is not assigned!");
            }
        }
    }
}

