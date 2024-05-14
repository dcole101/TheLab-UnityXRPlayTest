using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleportVisibility : MonoBehaviour
{
    public Transform player; // Reference to the player or XR origin manager
    public List<GameObject> targetObjects; // List of game objects to trigger
    public float triggerDistance = 5f; // Distance threshold for triggering the action

    void Update()
    {
        // Check if player and targetObjects are assigned
        if (player != null && targetObjects != null && targetObjects.Count > 0)
        {
            // Iterate through each target object
            foreach (GameObject targetObject in targetObjects)
            {
                // Calculate the distance between player and targetObject
                float distance = Vector3.Distance(player.position, targetObject.transform.position);

                // Check if the distance is within the triggerDistance
                if (distance <= triggerDistance)
                {
                    // Perform action here (replace with your desired code)
                    //Debug.Log("Player is close to " + targetObject.name);

                    targetObject.SetActive(false);


                }

                // Check if the distance is within the triggerDistance
                if (distance > triggerDistance)
                {
                    // Perform action here (replace with your desired code)
                    //Debug.Log("Player is leaving " + targetObject.name);

                    targetObject.SetActive(true);


                }
            }
        }
    }
}
