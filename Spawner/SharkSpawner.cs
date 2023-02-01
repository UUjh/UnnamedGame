using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SharkSpawner : MonoBehaviour
{
    public static SharkSpawner instance;

    public GameObject sharkPref;

    int randRot;

    bool wait;
    WaitForSeconds halfMin = new WaitForSeconds(30f);

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartSharkMaker();
    }

    void FixedUpdate()
    {
        if(!wait) StartCoroutine(SharkMaker());
    }

    IEnumerator SharkMaker()
    {
        wait = true;
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);
        GameObject ob = Instantiate(sharkPref, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
        yield return halfMin;
        wait = false;
    }

    void StartSharkMaker()
    {
        for (int i = 0; i < 3; i++)
        {
            randRot = Random.Range(0, 360);
            Quaternion rotation = Quaternion.Euler(0, randRot, 0);
            GameObject ob = Instantiate(sharkPref, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
        }
    }
}
