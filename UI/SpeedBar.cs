using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    public Slider speedSlider;

    public float speed;


    void Update()
    {
        speed = Player.instance.MoveSpeed;

        speedSlider.value = speed;

        if (speedSlider.value <= 0)
        {
            transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
