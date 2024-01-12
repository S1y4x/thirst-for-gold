using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSettings : MonoBehaviour
{
    private GameObject musicSlider, sfxSlider;
    private Slider musicSliderSlider, sfxSliderSlider;
    private float musicValue, sfxValue;
    void Start()
    {
        musicSlider = GameObject.Find("MusicLevelSlider");
        sfxSlider = GameObject.Find("SFXLevelSlider");
        musicSliderSlider = musicSlider.GetComponent<Slider>();
        sfxSliderSlider = sfxSlider.GetComponent<Slider>();
        musicValue = PlayerPrefs.GetFloat("Music");
        sfxValue = PlayerPrefs.GetFloat("SFX");
        musicSliderSlider.value = musicValue;
        sfxSliderSlider.value = sfxValue;
    }
}
