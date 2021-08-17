using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseresume : MonoBehaviour
{
    public void Pausebutton()
    {
        Time.timeScale = 0f;
    }
        public void Resumebutton()
    {
        Time.timeScale = 1f;
    }
}
