using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    public Slider o2Slider;

    public float o2;


    void Update()
    {
        o2 = Player.instance.Oxygen;

        o2Slider.value = o2 * 0.01f;

        if (o2Slider.value <= 0)
        {
            transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
