using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElement : MonoBehaviour
{
    public GameObject fireElementPrefab; // Reference to the FireElement prefab
    // State variable to track if the air element is activated
    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Toggle the air element effect when the CapsLock key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isTriggered)
            {
                fireElementPrefab.SetActive(true);
                isTriggered = true;
            }
            else
            {
                fireElementPrefab.SetActive(false);
                isTriggered = false;
            }
        }
    }
}
