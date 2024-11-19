using UnityEngine;

public class ShotgunMagScript : MonoBehaviour
{
    public ShotgunScript shotGun;
    public string magTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == magTag && shotGun.capacity < shotGun.maxCapacity && other.GetComponent<MagScript>().isGrabbed)
        {
            shotGun.MagIn();
            Destroy(other.gameObject);
        }
    }
}
