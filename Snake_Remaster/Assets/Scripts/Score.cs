using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public TextMeshProUGUI scoreText2;
    private int score2 = 0;

/*    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText2 = GetComponent<TextMeshProUGUI>();
    }*/
    private void Update()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoreText.text = "Score Green: " + score;
        scoreText2.text = "Score Red: " + score2;
    }
    public void IncreaseScore (int increment)
    {
        score += increment;
        RefreshUI();
    }
    public void IncreaseScore2(int increment)
    {
        score2 += increment;
        RefreshUI();
    }
    public void DecreaseScore (int decrease)
    {
        score -= decrease;
/*        scoreText.text = "Score Green: " + score;*/
/*        scoreText.text = "Score Red: " + score;*/
    }
    public void DecreaseScore2(int decrease)
    {
        /*        scoreText.text = "Score Green: " + score;*/
        score2 -= decrease;
        /*        scoreText.text = "Score Red: " + score;*/
    }
    /*    public void Score1Double(int scoredb)
        {
            score *= 2;
            scoreText.text = scoredb;
            RefreshUI();
        }*/


}
