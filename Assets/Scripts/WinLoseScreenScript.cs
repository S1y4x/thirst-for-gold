using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreenScript : MonoBehaviour
{
    public void BackToMenu(string MenuScene)
    {
        SceneManager.LoadScene(MenuScene);
    }
    public void PlayAgain(string MainScene)
    {
        SceneManager.LoadScene("MainScene");
    }
}
