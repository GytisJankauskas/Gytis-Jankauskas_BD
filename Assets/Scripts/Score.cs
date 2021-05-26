using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text username;

    int score;
    // Start is called before the first frame update

    void Start()
    {
        if (scoreText != null)
        {
            score = SaveSystem.Load(username.text).score;
            scoreText.text = score.ToString();
        }
    }

    public void UpdateScore(int addScore)  // updates score
    {
        if (scoreText != null)
        {
            score = score + addScore;
            scoreText.text = score.ToString();
            SaveSystem.Save(score, username.text);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
