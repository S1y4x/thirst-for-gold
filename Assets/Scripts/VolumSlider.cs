using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumSlider : MonoBehaviour
{
    private AudioSource audiosource;
    private float volumeValue;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        volumeValue = PlayerPrefs.GetFloat("Music");
    }
    void Update()
    {
        audiosource.volume = volumeValue;
    }
    public void SetVolume(float volume)
    {
        volumeValue = volume;
        PlayerPrefs.SetFloat("Music", volumeValue);
    }
}
