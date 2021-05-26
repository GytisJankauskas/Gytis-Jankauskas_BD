using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData // class for saving info and score
{
    public int score;

    public SaveData(int SaveScore)
    {
        score = SaveScore;
    }
}
