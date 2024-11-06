using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomObjectCreator : MonoBehaviour
{
    public GameObject[] randomObjects;
    public List<GameObject> objects = new List<GameObject>();
    public TextMeshProUGUI objectsCountText;
    public void InstantiateRandom()
    {
        int randomIndex = Random.Range(0, randomObjects.Length);
        objects.Add(Instantiate(randomObjects[randomIndex], transform.position, transform.rotation));
        objectsCountText.SetText($"Objects Count :{objects.Count}");
    }
}
