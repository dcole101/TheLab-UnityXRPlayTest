using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace UnityEngine.XR.Interaction.Toolkit.Inputs
{
    public class GoGoController : ActionBasedController
    {
        public Transform player;
        public float closeDistance;
        public float accelDistance;
        public float speed;

        private float startDistance = 0;
        private Vector3 previousPosition = Vector3.zero;
        protected override void UpdateTrackingInput(XRControllerState controllerState)
        {
            base.UpdateTrackingInput(controllerState);

            var posAction = positionAction.action;
            var hasPositionAction = posAction != null;

            if(hasPositionAction && (controllerState.inputTrackingState & InputTrackingState.Position) != 0)
            {
                var pos = posAction.ReadValue<Vector3>();

                //added
                if(previousPosition == Vector3.zero) { previousPosition = pos; }

                var handDistance = Vector3.Distance(player.position, pos);

                if(handDistance > closeDistance)
                {
                    if(startDistance == 0)
                    {
                        startDistance = handDistance;
                        previousPosition = pos;
                    }
                    var translatePoint = (handDistance - startDistance) * speed * (pos - previousPosition).normalized;
                    controllerState.position = pos + translatePoint;
                }
                else
                {
                    startDistance = 0;
                }

                if(Vector3.Distance(previousPosition, pos) > accelDistance) 
                { 
                    previousPosition = pos;
                }

               

            }

        }
    }









}


