using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform player; 
    public Transform teleportIndicator; 

    void Update(){
        if (Input.GetMouseButtonDown(0)){ // detect mouse click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                teleportIndicator.position = hit.point; 
                teleportIndicator.gameObject.SetActive(true); 
            }
        }

        if (Input.GetKeyDown(KeyCode.T)) 
        {
            if (teleportIndicator.gameObject.activeSelf) 
            {
                player.position = teleportIndicator.position; 
                // teleportIndicator.gameObject.SetActive(false); 
            }
        }
    }
}