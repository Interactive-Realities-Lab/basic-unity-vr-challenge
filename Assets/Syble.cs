using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syble : MonoBehaviour
{
    private Color defaultColor;

    private void Start()
    {
        defaultColor = GetComponent<MeshRenderer>().material.color;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Ball"))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            Invoke("ChangeColorToDefault", 1);
        }
    }
    private void ChangeColorToDefault()
    {
        GetComponent<MeshRenderer>().material.color = defaultColor;
    }
}
