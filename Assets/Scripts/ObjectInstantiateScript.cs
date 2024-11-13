using UnityEngine;

public class ObjectInstantiateScript : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject[] objects;
    public void InstantiateClickButton()
    {
        int i = Random.Range(0, objects.Length);
        GameObject x = Instantiate(objects[i], spawnPoint.position, Quaternion.identity);
    }
}
