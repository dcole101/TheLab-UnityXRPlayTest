using UnityEngine;
using UnityEngine.UI;

public class ChangeHue : MonoBehaviour
{
    // Reference to the Scrollbar
    public Scrollbar hueScrollbar;

    // Array of game objects with materials to change
    public GameObject[] objectsWithMaterials;

    // Reference to the materials you want to change (assuming they are shared materials)
    public Material[] materialsToChange;

    void Update()
    {
        // Get the current hue value from the scrollbar (ranges from 0 to 1)
        float hueValue = hueScrollbar.value;

        // Iterate through each object with materials
        foreach (GameObject obj in objectsWithMaterials)
        {
            // Check if the object exists
            if (obj != null)
            {
                // Get the renderer of the object
                Renderer renderer = obj.GetComponent<Renderer>();

                // Check if the renderer exists and has materials
                if (renderer != null && materialsToChange.Length > 0)
                {
                    // Iterate through each material and change the hue
                    foreach (Material material in materialsToChange)
                    {
                        // Change the hue of the material
                        ChangeMaterialHue(renderer, material, hueValue);
                    }
                }
            }
        }
    }

    void ChangeMaterialHue(Renderer renderer, Material material, float hue)
    {
        // Get the material's current color
        Color currentColor = material.color;

        // Convert the color to HSV
        Color.RGBToHSV(currentColor, out float h, out float s, out float v);

        // Set the new hue value
        h = hue;

        // Convert the updated HSV values back to RGB
        Color newColor = Color.HSVToRGB(h, s, v);

        // Set the material's color to the updated color
        material.color = newColor;

        // If the material is a shared material, apply the changes to the object's materials
        if (renderer.sharedMaterials.Length == renderer.materials.Length)
        {
            Material[] updatedMaterials = renderer.sharedMaterials;
            for (int i = 0; i < updatedMaterials.Length; i++)
            {
                if (updatedMaterials[i] == material)
                {
                    updatedMaterials[i] = material;
                }
            }
            renderer.sharedMaterials = updatedMaterials;
        }
    }
}
