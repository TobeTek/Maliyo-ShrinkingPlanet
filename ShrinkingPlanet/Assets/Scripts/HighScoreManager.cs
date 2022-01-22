using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;
    public Text highScoreText;
    private float highScore;
    public Text nameField; 
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {   
        highScore = PlayerPrefs.GetFloat("Highscore", 0.0f);
        try{
            UpdateHighScoreUI();
        }
        catch{
            // No Highscore Text
        }

    }

    public void SubmitScore()
    {
        HighScores.UploadScore(nameField.text, PlayerPrefs.GetFloat("Highscore",0.0f));
    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateHighScoreData(float newScore)
    {
        Debug.Log(newScore);
        Debug.Log(highScore);
        if(newScore <= highScore)
        {
            
            highScore = newScore;
            PlayerPrefs.SetFloat("Highscore", highScore);
        }
        else if(highScore == 0.0f){
            highScore = newScore;
            PlayerPrefs.SetFloat("Highscore", highScore);
        }
        
    }

    public void UpdateHighScoreUI()
    {
        highScoreText.text = highScore.ToString("0.#");
    }
    
}
