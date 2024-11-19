using UnityEngine;

public class RifleMagScript : MonoBehaviour
{
    public RifleScript rifle;
    public string magTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == magTag && rifle.ishavingMag == false && other.GetComponent<MagScript>().isGrabbed)
        {
            rifle.MagIn(other.GetComponent<MagScript>().capacity);
            Destroy(other.gameObject);
        }
    }
}
