using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    private bool _isGrabbed;
    [SerializeField]
    private bool _isRightHanded;
    [SerializeField]
    private GameObject _showMag;
    [SerializeField]
    public GameObject _dropPos;
    [SerializeField]
    public GameObject _mag;
    [SerializeField]
    public SimpleShoot _gun;
    public bool ishavingMag;
    public bool chamber;
    public int capacity = 0;

    void Start()
    {
        chamber = false;
        _isGrabbed = false;
        _isRightHanded = false;
        ishavingMag = false;
        _showMag.SetActive(false);
    }
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && _isGrabbed && _isRightHanded)
        {
            Shoots();
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && _isGrabbed && !_isRightHanded)
        {
            Shoots();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && _isGrabbed && _isRightHanded && ishavingMag)
        {
            MagOut();
        }
        if (OVRInput.GetDown(OVRInput.Button.Four) && _isGrabbed && !_isRightHanded && ishavingMag)
        {
            MagOut();
        }
    }
    public void SetChamber()
    {
        if (capacity > 0)
        {
            chamber = true;
            capacity--;
        }
        else
        {
            chamber = false;
        }
    }
    public void Shoots()
    {
        if (chamber)
        {
            chamber = false;
            _gun.ShootGun();
        }
        else
        {
            _gun.EmptyGun();
        }
    }
    public void MagOut()
    {
        _gun.MagOutSoundPlay();
        GameObject x = Instantiate(_mag, _dropPos.transform.position, Quaternion.identity);
        x.GetComponent<MagScript>().capacity = capacity;
        _showMag.SetActive(false);
        ishavingMag = false;
        capacity = 0;
    }
    public void MagIn(int x)
    {
        _gun.MagInSoundPlay();
        capacity = x;
        _showMag.SetActive(true);
        ishavingMag = true;
    }
    public void GrabGun()
    {
        _isGrabbed = true;
    }
    public void UngrabGun()
    {
        _isGrabbed = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            _isRightHanded = true;
        }
        if (other.gameObject.tag == "LeftHand")
        {
            _isRightHanded = false;
        }
    }
}
