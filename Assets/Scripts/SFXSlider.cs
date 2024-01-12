using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    private AudioSource audiosource, battleHorn;
    private GameObject mainScriptHere;

    private float volumeValue;
    void Start()
    {
        mainScriptHere = GameObject.Find("MainScriptHere");
        battleHorn = mainScriptHere.GetComponent<AudioSource>();
        audiosource = GetComponent<AudioSource>();
        volumeValue = PlayerPrefs.GetFloat("SFX");
    }
    void Update()
    {
        audiosource.volume = volumeValue;
        battleHorn.volume = volumeValue;
    }
    public void SetVolume(float volume)
    {
        volumeValue = volume;
        PlayerPrefs.SetFloat("SFX", volumeValue);
    }
}
