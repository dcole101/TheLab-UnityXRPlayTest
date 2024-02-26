using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class SnapMove : MonoBehaviour
{
    public XRController leftXRController;
    public float threshold = 0.1f; // Threshold for considering joystick input
    public InputActionReference actionRef;

    private void Update()
    {
     
    Vector2 aaa = actionRef.action.ReadValue<Vector2>();
    Debug.Log(aaa);

        //Check if the left XR Controller is connected
        if (leftXRController != null)
        {
  
                    // Get the joystick input
     
            
                        // Check if joystick input exceeds the threshold
                        if (aaa.magnitude > threshold)
                        {
                            // Print the joystick input to the console
                            Debug.Log("Left Controller Joystick Input: " + aaa);

                //take the vector
                //only one direction: forward
                //teleport user position to the jumped/snapped distance

                        }

                   
        }
    }
}


