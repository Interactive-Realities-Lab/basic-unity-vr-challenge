using UnityEngine;
using TMPro;

public class ObjectCounter : MonoBehaviour{
    public TextMeshProUGUI objectCounterText; 
    public string objectTag = "Spawnable";    // the tag of generated objects
    private int totalObjectCount = 0; // the number of objects in current scene

    public void InitializeWithExistingObjects(string tag){
        GameObject[] existingObjects = GameObject.FindGameObjectsWithTag(tag);
        totalObjectCount = existingObjects.Length;
        UpdateObjectCount();
    }

    public void UpdateObjectCount(){
        int dynamicObjectCount = GameObject.FindGameObjectsWithTag(objectTag).Length;
        totalObjectCount = dynamicObjectCount;
        if (objectCounterText != null){
            objectCounterText.text = "Objects: " + totalObjectCount;
        }
    }
}