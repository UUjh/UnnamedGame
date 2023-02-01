using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private int bestScore;
    private string bestPlayer;

    private string currentPlayer;
    private int currentScore;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    void Start()
    {
        currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
        bestPlayer = PlayerPrefs.GetString("BestPlayer");
        
    }

    public string BestPlayer
    {
        get;set;
    }
    public int BestScore
    {
        get;set;
    }

    public string CurrentPlayer
    {
        get; set;
    }
    public int CurrentScore
    {
        get; set;
    }

    public void BestScoreSave()
    {
        PlayerPrefs.SetInt("BestScore", (int)Player.instance.timer);
        PlayerPrefs.SetString("BestPlayer", currentPlayer);
    }

    //public void ScoreSet(int currentScore, string currentPlayer)
    //{
    //    PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);
    //    PlayerPrefs.SetString("CurrentPlayerName", currentPlayer);

    //    int tmpScore = 0;
    //    string tmpPlayer = "";

    //    bestPlayer = PlayerPrefs.GetString("BestPlayer");
    //    bestScore = PlayerPrefs.GetInt("BestScore");

    //    if(currentScore > bestScore)
    //    {
    //        tmpScore = bestScore;
    //        tmpPlayer = bestPlayer;
    //        bestScore = currentScore;
    //        bestPlayer = currentPlayer;

    //        PlayerPrefs.SetInt("BestScore", currentScore);
    //        PlayerPrefs.SetString("BsetPlayer", currentPlayer);

    //        currentScore = tmpScore;
    //        currentPlayer = tmpPlayer;
    //    }

    //}

}
