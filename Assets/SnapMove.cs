using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR;

public class SnapMove : MonoBehaviour
{
    public XRController leftXRController;
    public float threshold = 0.1f; // Threshold for considering joystick input

    private void Update()
    {
        //    // Check if the left XR Controller is connected
        //    if (leftXRController != null)
        //    {
        //        // Get the input device from the interaction manager
        //       XRController interactor = leftXRController.GetComponent<XRController>();
        //        if (interactor != null)
        //        {
        //            InputDevice inputDevice = interactor.XRController.inputDevice;

        //            // Check if the input device is associated with the left hand
        //            if (inputDevice.characteristics.HasFlag(InputDeviceCharacteristics.Left))
        //            {
        //                // Get the joystick input
        //                Vector2 joystickInput;
        //                if (inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickInput))
        //                {
        //                    // Check if joystick input exceeds the threshold
        //                    if (joystickInput.magnitude > threshold)
        //                    {
        //                        // Print the joystick input to the console
        //                        Debug.Log("Left Controller Joystick Input: " + joystickInput);
        //                    }
        //                }
        //            }
        //        }
        //    }
    }
}


