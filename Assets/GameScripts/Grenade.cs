using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = AK.Wwise.Event;

public class Grenade : MonoBehaviour
{
    public Event explodeSound;
    public GameObject grenadeLightSource;
    private readonly bool Triggered = false;
    private bool Exploded;
    private Light grenadeLight;
    private ParticleSystem particleSystem;
    private HashSet<Collider> zombies;

    private void Start()
    {
        particleSystem = transform.Find("Spheres Explode").GetComponent<ParticleSystem>();
        grenadeLight = grenadeLightSource.GetComponent<Light>();
        grenadeLight.intensity = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !Triggered)
            if (OVRInput.GetDown(OVRInput.RawButton.A))
                StartCoroutine(DelayedExplode());
    }

    private IEnumerator DelayedExplode()
    {
        yield return new WaitForSeconds(5);
        ExplodePlay();
    }

    private IEnumerator DestroyAfterParticle(ParticleSystem particleSystem)
    {
        while (particleSystem.isPlaying) yield return null;
        Destroy(gameObject);
    }

    private void ExplodePlay()
    {
        if (!Exploded)
        {
            var grenade = transform.Find("GrenadeMesh");
            explodeSound.Post(gameObject);
            grenade.gameObject.SetActive(false);
            particleSystem.Play();
            StartCoroutine(FlashLight());
            StartCoroutine(DestroyAfterParticle(particleSystem));

            zombies = transform.Find("DamageZone").GetComponent<GrenadeDestroy>().GetCollidersInTrigger();
            foreach (var collider in zombies)
                if (collider.gameObject.layer == LayerMask.NameToLayer("Actor"))
                {
                    collider.gameObject.GetComponent<ZombieState>().health = 0;
                    collider.gameObject.GetComponent<ZombieState>().StateUpdate();
                }
                else
                {
                    Destroy(collider.gameObject);
                }

            Exploded = true;
        }
    }

    private IEnumerator FlashLight()
    {
        grenadeLight.intensity = 4;
        yield return new WaitForSeconds(0.1f);
        grenadeLight.intensity = 0;
    }
}