using UnityEngine;

public class ResetObjects : MonoBehaviour
{
    // Array to store initial positions of game objects
    private Vector3[] initialPositions;

    // Array to store game objects to be reset
    public GameObject[] objectsToReset;

    void Start()
    {
        // Store initial positions of objects
        StoreInitialPositions();
    }

    void StoreInitialPositions()
    {
        initialPositions = new Vector3[objectsToReset.Length];
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            initialPositions[i] = objectsToReset[i].transform.position;
        }
    }

    public void ResetObjectPositions()
    {
        // Reset positions of objects to their initial positions
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].transform.position = initialPositions[i];
        }
    }
}
