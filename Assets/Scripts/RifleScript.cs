using UnityEngine;

public class RifleScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip _gunShootSound;
    [SerializeField]
    private AudioClip _emptyShootSound;
    [SerializeField]
    private AudioClip _frontSliderSound;
    [SerializeField]
    private AudioClip _backSliderSound;
    [SerializeField]
    private AudioClip _magInSound;
    [SerializeField]
    private AudioClip _magOutSound;
    [SerializeField]
    private bool _isGrabbed;
    [SerializeField]
    private bool _isRightHanded;
    [SerializeField]
    private GameObject _mag;
    [SerializeField]
    private GameObject _showMag;
    [SerializeField]
    private Transform _dropPos;
    public GameObject loadedBulletPrefab;
    [SerializeField]
    private bool isSingleAction = true;
    public bool chamber;
    public bool ishavingMag;
    public bool inShell;
    public int capacity = 0;
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public GameObject casingPrefab;
    public Transform casingExitLocation;
    public Transform barrelLocation;
    public float destroyTimer = 2f;
    public float shotPower = 500f;
    public float ejectPower = 500f;
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
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && _isGrabbed && _isRightHanded)
        {
            StopShoots();
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && _isGrabbed && !_isRightHanded)
        {
            StopShoots();
        }
        if (OVRInput.GetDown(OVRInput.Button.Two) && _isGrabbed && _isRightHanded && ishavingMag)
        {
            MagOut();
        }
        if (OVRInput.GetDown(OVRInput.Button.Four) && _isGrabbed && !_isRightHanded && ishavingMag)
        {
            MagOut();
        }
        if (OVRInput.GetDown(OVRInput.Button.One) && _isGrabbed && _isRightHanded)
        {
            isSingleAction = !isSingleAction;
        }
        if (OVRInput.GetDown(OVRInput.Button.Three) && _isGrabbed && !_isRightHanded)
        {
            isSingleAction = !isSingleAction;
        }
    }
    public void GunShootSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip = _gunShootSound;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void EmptyShootSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip = _emptyShootSound;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void FrontSliderSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip = _frontSliderSound;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void BackSliderSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip = _backSliderSound;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void MagInSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip = _magInSound;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void MagOutSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip = _magOutSound;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void Fire()
    {
        if (chamber)
        {
            chamber = false;
            SetSliderFront();
            if (muzzleFlashPrefab)
            {
                GameObject tempFlash;
                tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
                Destroy(tempFlash, destroyTimer);
            }
            if (!bulletPrefab)
            { return; }
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            CasingRelease();
        }
        else
        {
            StopShoots();
        }
    }
    public void Shoots()
    {
        if (chamber)
        {
            if (!isSingleAction)
            {
                gameObject.GetComponent<Animator>().SetBool("Fire", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetTrigger("SingleFire");
            }
        }
        else
        {
            EmptyShootSoundPlay();
        }
    }
    public void StopShoots()
    {
        gameObject.GetComponent<Animator>().SetBool("Fire", false);
    }
    void CasingRelease()
    {
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
        Destroy(tempCasing, destroyTimer);
    }
    void ExtingBullet()
    {
        GameObject tempBullet;
        tempBullet = Instantiate(loadedBulletPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        tempBullet.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        tempBullet.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
        Destroy(tempBullet, destroyTimer);
    }
    public void MagOut()
    {
        MagOutSoundPlay();
        GameObject x = Instantiate(_mag, _dropPos.transform.position, Quaternion.identity);
        x.GetComponent<MagScript>().capacity = capacity;
        _showMag.SetActive(false);
        ishavingMag = false;
        capacity = 0;
    }
    public void MagIn(int x)
    {
        MagInSoundPlay();
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
    public void SetSliderFront()
    {
        if (capacity>0)
        {
            capacity--;
            chamber = true;
        }
    }
    public void SetSliderBack()
    {
        if (chamber)
        {
            chamber = false;
            ExtingBullet();
        }
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
