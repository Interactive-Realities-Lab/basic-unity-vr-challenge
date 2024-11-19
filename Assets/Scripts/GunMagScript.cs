using UnityEngine;

public class GunMagScript : MonoBehaviour
{
    public GameObject gun;
    public string magTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == magTag && gun.GetComponent<GunScript>().ishavingMag == false && other.GetComponent<MagScript>().isGrabbed)
        {
            gun.GetComponent<GunScript>().MagIn(other.GetComponent<MagScript>().capacity);
            Destroy(other.gameObject);
        }
    }
}
