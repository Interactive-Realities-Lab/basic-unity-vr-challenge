using UnityEngine;

public class ShotgunScript : MonoBehaviour
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
    private bool _isGrabbed;
    [SerializeField]
    private bool _isRightHanded;
    public bool chamber;
    public bool inShell;
    public int capacity = 0;
    public int maxCapacity = 7;
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public GameObject casingPrefab;
    public Transform casingExitLocation;
    public Transform barrelLocation;
    public Transform barrelLocation1;
    public Transform barrelLocation2;
    public Transform barrelLocation3;
    public Transform barrelLocation4;
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
    public void Fire()
    {
        if (muzzleFlashPrefab)
        {
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            Destroy(tempFlash, destroyTimer);
        }
        if (!bulletPrefab)
        { return; }
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Instantiate(bulletPrefab, barrelLocation1.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Instantiate(bulletPrefab, barrelLocation2.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Instantiate(bulletPrefab, barrelLocation3.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Instantiate(bulletPrefab, barrelLocation4.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
    }
    public void Shoots()
    {
        if (chamber)
        {
            chamber = false;
            gameObject.GetComponent<Animator>().SetTrigger("Fire");
            GunShootSoundPlay();
        }
        else
        {
            EmptyShootSoundPlay();
        }
    }
    void CasingRelease()
    {
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
        Destroy(tempCasing, destroyTimer);
    }
    public void MagIn()
    {
        capacity++;
        MagInSoundPlay();
    }
    public void GrabGun()
    {
        _isGrabbed = true;
    }
    public void UngrabGun()
    {
        _isGrabbed = false;
    }
    public void BackSlide()
    {
        BackSliderSoundPlay();
        if (inShell)
        {
            CasingRelease();
            inShell = false;
        }
    }
    public void FrontSlide()
    {
        FrontSliderSoundPlay();
        if (capacity > 0)
        {
            capacity--;
            chamber = true;
            inShell = true;
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
