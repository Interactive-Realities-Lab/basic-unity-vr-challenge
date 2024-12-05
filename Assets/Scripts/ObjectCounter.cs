using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ObjectCounter : MonoBehaviour
{
    public TextMeshProUGUI countText; // Reference to TextMeshPro UI element
    private int objectCount = 0;

    public void UpdateObjectCount()
    {
        objectCount++;
        countText.text = "Objects: " + objectCount;
    }
}
