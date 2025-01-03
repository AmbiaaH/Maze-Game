using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
