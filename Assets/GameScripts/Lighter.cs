using UnityEngine;

public class Lighter : MonoBehaviour
{
    public Material LighterMaterial;
    public Material UnlightedMaterial;
    private bool Lighted = true;

    private void Start()
    {
        ChangeLighter();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) &&
                OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
                ChangeLighter();
            else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) &&
                     OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
                ChangeLighter();
    }

    private void ChangeLighter()
    {
        Material glowMaterial;
        var renderer = GetComponent<Renderer>();
        var pointLight = transform.Find("Point Light").GetComponent<Light>();
        //glowMaterial = renderer.material;

        if (Lighted)
        {
            pointLight.enabled = false;
            renderer.material = UnlightedMaterial;
            Lighted = false;
        }
        else
        {
            pointLight.enabled = true;
            renderer.material = LighterMaterial;
            Lighted = true;
        }
    }
}