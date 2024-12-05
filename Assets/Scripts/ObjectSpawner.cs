using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Array to store the objects that you want to spawn
    public GameObject[] objectsToSpawn;

    // The location where the objects will spawn
    public Transform spawnLocation;

    // Method to spawn a random object
    public void SpawnObject()
    {
        int index = Random.Range(0, objectsToSpawn.Length);  // Get a random index
        Instantiate(objectsToSpawn[index], spawnLocation.position, Quaternion.identity);  // Spawn the object at the spawn location
    }
}
