using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    public GameObject slider;
    public GameObject sliderText;
    public GameObject dropDown;
    public GameObject gunText;
    public GameObject grenadeText;
    public GameObject glowStickText;

    public GameObject gun;
    public GameObject grenade;
    public GameObject glowStick;

    private int glowStickCount;
    private int grenadeCount;
    private int gunCount;

    private int sliderValue;
    private string weaponSelect = "Select Weapon";

    public void SpawnWeaponClick()
    {
        GetSelectorValue();
        switch (weaponSelect)
        {
            case "Select Weapon":
                break;
            case "GlowStick":
                // Spawn GlowStick
                for (var i = 0; i < sliderValue; i++)
                    Instantiate(glowStick, transform.position, transform.rotation);
                glowStickCount += sliderValue;
                glowStickText.GetComponent<TMP_Text>().text = glowStickCount.ToString();
                break;
            case "Gun":
                // spawn Gun
                for (var i = 0; i < sliderValue; i++)
                    Instantiate(gun, transform.position, transform.rotation);
                gunCount += sliderValue;
                gunText.GetComponent<TMP_Text>().text = gunCount.ToString();
                break;
            case "Grenade":
                // spawn grenade
                for (var i = 0; i < sliderValue; i++)
                    Instantiate(grenade, transform.position, transform.rotation);
                grenadeCount += sliderValue;
                grenadeText.GetComponent<TMP_Text>().text = grenadeCount.ToString();
                break;
        }
    }

    public int GetBarValue()
    {
        sliderValue = (int)Math.Round(slider.GetComponent<Slider>().value * 10);
        return sliderValue;
    }

    public void SetSliderValue()
    {
        GetBarValue();
        sliderText.GetComponent<TMP_Text>().text = sliderValue.ToString();
    }

    public string GetSelectorValue()
    {
        weaponSelect = dropDown.GetComponent<TMP_Dropdown>().options[dropDown.GetComponent<TMP_Dropdown>().value].text;
        return weaponSelect;
    }
}