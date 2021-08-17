using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Lobby : MonoBehaviour
{
    public Button Play;
    private void Awake()
    {
        Play.onClick.AddListener(Playgame);
    }

    private void Playgame()
    {
     SceneManager.LoadScene(0);
    }
}
