using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static int recentScore = 0;
    public static int highScore = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        recentScore = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (recentScore > highScore)
        {
            highScore = recentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if (recentScore < 10)
        {
            ScoreText.text = "Recent Score: \n000" + recentScore;
        } 
        else if (recentScore < 100)
        {
            ScoreText.text = "Recent Score: \n00" + recentScore;
        }
        else if (recentScore < 1000)
        {
            ScoreText.text = "Recent Score: \n0" + recentScore;
        }
        else
        {
            ScoreText.text = "Recent Score: \n" + recentScore;
        }
        HighScoreText.text = "Highest Score: " + highScore;
    }
}

