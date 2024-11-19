using UnityEngine;

public class SliderShotgunScript : MonoBehaviour
{
    public ShotgunScript shotGun;
    public GameObject sliderPos;

    void Update()
    {
        gameObject.transform.position = sliderPos.transform.position;
        gameObject.transform.rotation = sliderPos.transform.rotation;
    }
    public void BackSlide()
    {
        shotGun.GetComponent<Animator>().SetBool("BackSlider", true);
        shotGun.GetComponent<Animator>().SetBool("FrontSlider", false);
    }
    public void FrontSlide()
    {
        shotGun.GetComponent<Animator>().SetBool("FrontSlider", true);
        shotGun.GetComponent<Animator>().SetBool("BackSlider", false);
    }
}
