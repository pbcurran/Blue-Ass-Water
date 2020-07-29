using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int currentScore = 0;
    public int multiplier = 1;
    int multiplieriterator = 0;

    private void Awake()
    {
        SetUpSingleTon();
    }

    private void SetUpSingleTon()
    {
        int numberGameSessions = FindObjectsOfType<ScoreKeeper>().Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int pointsAdded)
    {
        currentScore += (pointsAdded * this.multiplier);
    }

    public void SetMultiplier()
    {
        multiplieriterator++;
        if (multiplieriterator >= 8 && multiplieriterator < 16)
        {
            this.multiplier = 2;
        }
        if (multiplieriterator >= 16 && multiplieriterator < 24)
        {
            this.multiplier = 3;
        }
        if (multiplieriterator >= 24)
        {
            this.multiplier = 4;
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public int GetScore()
    {
        return this.currentScore;
    }

    public int GetMultiplier()
    {
        return this.multiplier;
    }

    public void ResetMultiplier()
    {
        multiplieriterator = 0;
        this.multiplier = 1;
    }
}
