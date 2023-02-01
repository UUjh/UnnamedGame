using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextsManager : MonoBehaviour
{
    public static TextsManager instance;

    public TextMeshProUGUI gameOverTxt;
    public TextMeshProUGUI recordsTxt;
    public TextMeshProUGUI timerTxt;


    string bestPlayer;
    string currentPlayer;
    int bestScore;
    int currentScore;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        bestPlayer = PlayerPrefs.GetString("BestPlayer");
        bestScore = PlayerPrefs.GetInt("BestScore");
    }


    void Update()
    {
        timerTxt.text = "Timer:   " + (int)Player.instance.timer + "  sec";
        if(Player.instance.IsDead)
        {
            bestPlayer = PlayerPrefs.GetString("BestPlayer");
            bestScore = PlayerPrefs.GetInt("BestScore");

            gameOverTxt.gameObject.SetActive(true);
            recordsTxt.text = "Your Record\n" + Player.instance.currentScore + "\n1ST\n" +
                "Name: " + bestPlayer + "\nRecord: " + bestScore;
            recordsTxt.gameObject.SetActive(true);
        }
        else
        {
            gameOverTxt.gameObject.SetActive(false);
            recordsTxt.gameObject.SetActive(false);
        }
    }
}
