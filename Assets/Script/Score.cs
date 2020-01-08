using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    // Keeps score object
    static private int currentScore;
    static public int localtime;
    public int localScore;

    public void DecrementLocalTime()
    {
        localtime += localtime > 0 ? -1 : 0; 
    }

    public void SetLocalTime(int time)
    {
        localtime = time;
    }

    public int GetLocalTime()
    {
        return localtime;
    }

    public void SetScore(int score)
    {
        currentScore = score;
    }

    public void AddScore(int score)
    {
        currentScore = this.CheckScore(currentScore + score);
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    private int CheckScore(int score)
    {
        if (score < 0)
            score = 0;

        return score;
    }
}
