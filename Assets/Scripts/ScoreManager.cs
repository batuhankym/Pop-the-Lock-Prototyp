using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    
    
    public TMP_Text scoreText;
    public int _score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    public void IncreaseScore(int amountToScore)
    {
        _score = _score += amountToScore;
        scoreText.text = _score.ToString();

    }
}
