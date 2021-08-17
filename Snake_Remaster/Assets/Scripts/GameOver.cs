 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public Button buttonRestart;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
/*    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }*/
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

}