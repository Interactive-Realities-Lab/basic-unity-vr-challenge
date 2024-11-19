using UnityEngine;

public class SliderRifleScript : MonoBehaviour
{
    public RifleScript rifle;
    public GameObject sliderPos;

    void Update()
    {
        gameObject.transform.position = sliderPos.transform.position;
        gameObject.transform.rotation = sliderPos.transform.rotation;
    }
    public void BackSlide()
    {
        rifle.GetComponent<Animator>().SetBool("BackSlider", true);
        rifle.GetComponent<Animator>().SetBool("FrontSlider", false);
        rifle.GetComponent<Animator>().SetBool("Fire", false);
    }
    public void FrontSlide()
    {
        rifle.GetComponent<Animator>().SetBool("FrontSlider", true);
        rifle.GetComponent<Animator>().SetBool("BackSlider", false);
        rifle.GetComponent<Animator>().SetBool("Fire", false);
    }
}
