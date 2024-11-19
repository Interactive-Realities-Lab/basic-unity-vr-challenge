using UnityEngine;

public class GrabbableFixScript : MonoBehaviour
{
    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
