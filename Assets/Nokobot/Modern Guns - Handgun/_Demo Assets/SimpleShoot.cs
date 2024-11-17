using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Sound Refrences")]
    public GunScript gun;
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

    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject loadedBulletPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }
    public void SetBulletInChamber()
    {
        gun.SetChamber();
    }
    public void GunShootSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip= _gunShootSound;
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
    public void ShootGun()
    {
        gunAnimator.SetTrigger("Fire");
    }
    public void EmptyGun()
    {
        gunAnimator.SetBool("EmptyMag", true);
        gunAnimator.SetBool("FrontSlider", false);
        gunAnimator.SetBool("BackSlider", false);
    }
    public void SetSliderFront()
    {
        gunAnimator.SetBool("FrontSlider", true);
        gunAnimator.SetBool("EmptyMag", false);
        gunAnimator.SetBool("BackSlider", false);
    }
    public void SetSliderBack()
    {
        gunAnimator.SetBool("BackSlider", true);
        gunAnimator.SetBool("FrontSlider", false);
        gunAnimator.SetBool("EmptyMag", false);
    }
    //This function creates the bullet behavior
    void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

    void ExtingBullet()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!gun.chamber)
        { return; }

        if (!casingExitLocation || !loadedBulletPrefab)
        { return; }

        //Create the casing
        GameObject tempBullet;
        tempBullet = Instantiate(loadedBulletPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempBullet.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempBullet.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempBullet, destroyTimer);
    }
}
