using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectHighlightScript : MonoBehaviour
{
    public Shader defaultShader;
    public Shader highlightedShader;
    public Shader redShader;
    public Shader chosenShader;

    public void OnFirstHoverEntered(HoverEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            chosenShader = redShader;
            Debug.Log("Shader set to direct interactor");
        }
        else if (args.interactorObject is XRRayInteractor)
        {
            chosenShader = highlightedShader;
            Debug.Log("Shader set to ray interactor");
        }

        var renderer = args.interactableObject.transform.GetComponent<Renderer>();
        renderer.material.shader = chosenShader;
    }

    public void OnLastHoverExited(HoverExitEventArgs args)
    {
        if (!args.interactableObject.isHovered)
        {
            var renderer = args.interactableObject.transform.GetComponent<Renderer>();
            renderer.material.shader = defaultShader;
        }
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            chosenShader = redShader;
            Debug.Log("Shader set to direct interactor");
        }
        else if (args.interactorObject is XRRayInteractor)
        {
            chosenShader = highlightedShader;
            Debug.Log("Shader set to ray interactor");
        }

        var renderer = args.interactableObject.transform.GetComponent<Renderer>();
        renderer.material.shader = chosenShader;
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        if (!args.interactableObject.isSelected)
        {
            var renderer = args.interactableObject.transform.GetComponent<Renderer>();
            renderer.material.shader = defaultShader;
        }
    }
}
