using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuPause : MonoBehaviour
{
    private GameObject music, sfx;
    private Slider musicSlider, sfxSlider;

    private void Start()
    {
        music = GameObject.Find("MusicVolumeSlider");
        sfx = GameObject.Find("SFXVolumeSlider");
        musicSlider = music.GetComponent<Slider>();
        sfxSlider = sfx.GetComponent<Slider>();
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
    }
    public void Unpause()
    {
        Time.timeScale = 1;
    }
    public void BackToMenuScene(string MenuScene)
    {
        SceneManager.LoadScene(MenuScene);
    }
}
