using UnityEngine;

public class ChangeColorOnGrab : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color originalColor;

    void Start()
    {
        // Get the MeshRenderer component
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            // Store the original color of the cube
            originalColor = meshRenderer.material.color;
        }
    }

    // Change the color when the cube is grabbed
    public void OnGrabbed()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = Color.green; // Change to the grabbed color
        }
    }

    // Revert the color when the cube is released
    public void OnReleased()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.color = originalColor; // Revert to the original color
        }
    }
}
