using UnityEngine;

public class MagScript : MonoBehaviour
{
    public int capacity = 7;
    public bool isGrabbed = false;
    public void GrabMag()
    {
        isGrabbed = true;
    }
    public void UngrabMag()
    {
        isGrabbed = false;
    }

}
