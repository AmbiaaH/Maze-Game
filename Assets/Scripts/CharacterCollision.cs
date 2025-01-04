using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollision : MonoBehaviour
{
    public GameObject fireElementPrefab;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("IceMountain"))
        {
            if (fireElementPrefab.activeSelf)
            {
                Destroy(hit.gameObject);
            }
        }

        if (hit.gameObject.CompareTag("Lava"))
        {
            // Load the LoseScreen scene
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
