using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMountain : MonoBehaviour
{
    public GameObject fireElementPrefab; // Reference to the FireElement prefab

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision happend.");

        if (collision.gameObject.CompareTag("Player"))
        {
            if (fireElementPrefab.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }

        
    }
}