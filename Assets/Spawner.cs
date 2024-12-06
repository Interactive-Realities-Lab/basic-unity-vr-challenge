using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject mySphere;

   /*public void SpawnSphere()
    {
        Vector3 spawnPosition = new Vector3(-1, 0, 1);
        Instantiate (mySphere, spawnPosition, Quaternion.identity);
    }*/

    public void SpawnSphere()
    
    {

        int spawnPointX = Random.Range(-1,1);
        int spawnPointY = Random.Range(1,2);
        int spawnPointZ = Random.Range(-1,1);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
        Instantiate (mySphere, spawnPosition, Quaternion.identity);
    }
}
