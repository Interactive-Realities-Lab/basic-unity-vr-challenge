using System.Collections;
using UnityEngine;
using Event = AK.Wwise.Event;

[RequireComponent(typeof(LineRenderer))]
public class Gun : MonoBehaviour
{
    public Transform rayOrigin;
    public LayerMask actorLayerMask;
    public GameObject gunFire;

    public Event gunFireSound;
    private RaycastHit hitInfo;
    private LineRenderer lineRenderer;
    private Light spotLight;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        spotLight = gunFire.GetComponent<Light>();
        spotLight.intensity = 0f;
    }

    private void Update()
    {
        var ray = new Ray(rayOrigin.position, rayOrigin.forward);

        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, actorLayerMask))
        {
            lineRenderer.SetPosition(0, rayOrigin.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, rayOrigin.position);
            lineRenderer.SetPosition(1, rayOrigin.position + rayOrigin.forward * 10);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) &&
                OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
                GunFire();
    }

    private void GunFire()
    {
        var zombie = hitInfo.collider.gameObject;
        StartCoroutine(FlashLight());
        gunFireSound.Post(gameObject);
        if (zombie.layer == LayerMask.NameToLayer("Actor"))
        {
            zombie.GetComponent<ZombieState>().health -= 1;
            zombie.GetComponent<ZombieState>().StateUpdate();
        }
    }

    private IEnumerator FlashLight()
    {
        spotLight.intensity = 4;
        yield return new WaitForSeconds(0.1f);
        spotLight.intensity = 0;
    }
}