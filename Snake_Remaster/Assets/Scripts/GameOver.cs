 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public Button Restart;
    private void Awake()
    {
        Restart.onClick.AddListener(ReloadLevel);
    }
    public void SnakeDied()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

}
