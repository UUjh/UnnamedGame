using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPBar : MonoBehaviour
{

    public Slider expSlider;
    public TextMeshProUGUI levelTxt;

    public int exp;

    void Start()
    {
        levelTxt.text = "Lv. " + Player.instance.Level;
    }

    void Update()
    {
        exp = Player.instance.Exp;
        levelTxt.text = "Lv. " + Player.instance.Level;


        expSlider.value = exp;
        expSlider.maxValue = Player.instance.MaxExp;

        if (expSlider.value <= 0)
        {
            transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
