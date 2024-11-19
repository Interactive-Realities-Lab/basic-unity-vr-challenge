using UnityEngine;

public class SliderScript : MonoBehaviour
{
    public SimpleShoot gun;
    public GameObject sliderPos;

    void Update()
    {
        gameObject.transform.position = sliderPos.transform.position;
        gameObject.transform.rotation = sliderPos.transform.rotation;
    }
    public void BackSlide()
    {
        gun.SetSliderBack();
    }
    public void FrontSlide()
    {
        gun.SetSliderFront();
    }
}
