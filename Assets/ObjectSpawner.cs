using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour{
    public ObjectCounter objectCounter; 
    public GameObject[] spawnableObjects; 
    public Transform spawnArea; 
    public float spawnRadius = 5f; 
    [SerializeField] private string objectTag = "Spawnable"; 
    private List<GameObject> spawnedObjects = new List<GameObject>(); 

    void Start(){
        if (objectCounter != null){
            objectCounter.InitializeWithExistingObjects(objectTag);
        }
    }

    public void SpawnRandomObject(){
        if (spawnableObjects.Length == 0) return;
        GameObject prefab = spawnableObjects[Random.Range(0, spawnableObjects.Length)];
        Vector3 randomPosition = spawnArea.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), 0.5f, Random.Range(-spawnRadius, spawnRadius));

        GameObject newObject = Instantiate(prefab, randomPosition, Quaternion.identity);
        newObject.tag = objectTag; 
        spawnedObjects.Add(newObject); 

        if (objectCounter != null){
            objectCounter.UpdateObjectCount();
        }
    }

    public void DeleteRandomObject()
    {
        if (spawnedObjects.Count == 0) return;
        int randomIndex = Random.Range(0, spawnedObjects.Count);
        GameObject objectToDelete = spawnedObjects[randomIndex];
        spawnedObjects.RemoveAt(randomIndex);
        Destroy(objectToDelete);

        if (objectCounter != null){
            objectCounter.UpdateObjectCount();
        }
    }
}