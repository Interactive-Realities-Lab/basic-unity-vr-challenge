using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    private Renderer objectRenderer;

    private void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        // Change the object's material color to a random color
        objectRenderer.material.color = Random.ColorHSV();
    }
}

