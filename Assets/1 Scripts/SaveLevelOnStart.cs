using UnityEngine;

public class SaveLevelOnStart : MonoBehaviour
{
    private void Start()
    {
        // Save the current level as soon as the scene starts
        RetryGame.SaveCurrentLevel();
    }
}
