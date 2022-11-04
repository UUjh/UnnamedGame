using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public TMP_InputField inputName;

    string playerName;

    void Start()
    {
    }

    void Update()
    {
        
    }
    public void StartBtn()
    {
        if (inputName.text == "")
        {
            Debug.Log("unnamed");
            playerName = "Unnamed";
            PlayerPrefs.SetString("CurrentPlayer", playerName);
            SceneManager.LoadScene("Main");
        }
        else
        {
            playerName = inputName.text;
            Debug.Log(playerName);
            PlayerPrefs.SetString("CurrentPlayer", playerName);
            SceneManager.LoadScene("Main");
        }
    }
    public void HowtoPlayBtn()
    {
        //HTP.instance.PaperOpen();
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
