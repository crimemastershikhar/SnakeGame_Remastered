using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Lobby : MonoBehaviour
{
    public Button Play;
    public Button Quit;
    private void Awake()
    {
        Play.onClick.AddListener(Playgame);
        Play.onClick.AddListener(Quitgame);
    }

    private void Playgame()
    {
     SceneManager.LoadScene(0);
    }
    private void Quitgame()
    {
        Application.Quit();
    }
}
