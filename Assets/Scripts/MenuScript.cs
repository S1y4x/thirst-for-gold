using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private GameObject click, music, paper;
    private AudioSource mainTheme, clickSound, pageTurnOverSound;
    private float musicLevel, sfxLevel;
    public void StartGame(string MainScene)
    {
        SceneManager.LoadScene(MainScene);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    void Start()
    {        
        music = GameObject.Find("MusicTheme");
        mainTheme = music.GetComponent<AudioSource>();
        click = GameObject.Find("ClickSound");
        clickSound = click.GetComponent<AudioSource>();
        paper = GameObject.Find("PageTurnOverSound");
        pageTurnOverSound = paper.GetComponent<AudioSource>();
        musicLevel = PlayerPrefs.GetFloat("Music");
        sfxLevel = PlayerPrefs.GetFloat("SFX");     
    }

    void Update()
    {
        mainTheme.volume = musicLevel;
        clickSound.volume = sfxLevel;
        pageTurnOverSound.volume = sfxLevel;
    }

    public void SetMusicVolume(float musicVolume)
    {
        musicLevel = musicVolume;
        PlayerPrefs.SetFloat("Music", musicLevel);
    }
    public void SetSFXVolume(float sfxVolume)
    {
        sfxLevel = sfxVolume;
        PlayerPrefs.SetFloat("SFX", sfxLevel);
    }
}
