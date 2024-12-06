using TMPro; // Add this namespace
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Use TextMeshProUGUI for TextMeshPro elements
    public string tagToCount = "Countable";

    void Update()
    {
        int objectCount = GameObject.FindGameObjectsWithTag(tagToCount).Length;
        counterText.text = $"Objects in Scene: {objectCount}";
    }
}
