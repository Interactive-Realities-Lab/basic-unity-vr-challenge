using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ChangeColorOnGrab : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public Color defaultColor;
    public Color grabbedColor;
    public Color placedColor;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnGrabbed()
    {
        meshRenderer.material.color = grabbedColor;
    }

    public void OnPlaced()
    {
        meshRenderer.material.color = placedColor;
    }
    public void OnFloor()
    {
        meshRenderer.material.color = defaultColor;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Floor"))
        {
            OnFloor();
        }

    }
}
