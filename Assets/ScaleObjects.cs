using UnityEngine;

public class ScaleObjects : MonoBehaviour
{
    // Reference to the buttons
    public UnityEngine.UI.Button scaleUpButton;
    public UnityEngine.UI.Button scaleDownButton;

    // Array of game objects to be scaled
    public GameObject[] objectsToScale;

    // The amount by which the objects should be scaled
    public float scaleMultiplier = 1.5f;

    void Start()
    {
        // Add listeners to the buttons' click events
        scaleUpButton.onClick.AddListener(OnScaleUpButtonClicked);
        scaleDownButton.onClick.AddListener(OnScaleDownButtonClicked);
    }

    void OnScaleUpButtonClicked()
    {
        // Iterate through each object and scale them up
        foreach (GameObject obj in objectsToScale)
        {
            // Check if the object exists
            if (obj != null)
            {
                // Scale the object up
                obj.transform.localScale *= scaleMultiplier;
            }
        }
    }

    void OnScaleDownButtonClicked()
    {
        // Iterate through each object and scale them down
        foreach (GameObject obj in objectsToScale)
        {
            // Check if the object exists
            if (obj != null)
            {
                // Scale the object down
                obj.transform.localScale /= scaleMultiplier;
            }
        }
    }
}
