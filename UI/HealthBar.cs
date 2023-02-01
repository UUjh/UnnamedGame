using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hpSlider;

    public float hp;


    void Update()
    {
        hp = Player.instance.Health;

        hpSlider.value = hp * 0.01f;

        if (hpSlider.value <= 0)
        {
            transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
