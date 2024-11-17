using UnityEngine;

public class FallFixScript : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, 0.5f, collision.gameObject.transform.position.y);
        Debug.LogError("KIIIIR");
    }
}
