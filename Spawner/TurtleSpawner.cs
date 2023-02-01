using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurtleSpawner : MonoBehaviour
{
    public static TurtleSpawner instance;

    public GameObject turtlePref;

    bool wait;
    int randRot;
    WaitForSeconds oneMin = new WaitForSeconds(60f);


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        FirstTutleMaker();
    }

    void FixedUpdate()
    {
        if(!wait) StartCoroutine(TurtleMaker());
    }

    IEnumerator TurtleMaker()
    {
        wait = true;
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);
        GameObject ob = Instantiate(turtlePref, new Vector3(Random.Range(-1000f, 1000f), -163f, Random.Range(-1000f, 1000f)), rotation);
        yield return oneMin;
        wait = false;
    }

    void FirstTutleMaker()
    {
        for (int i = 0; i < 3; i++)
        {
            randRot = Random.Range(0, 360);
            Quaternion rotation = Quaternion.Euler(0, randRot, 0);
            GameObject ob = Instantiate(turtlePref, new Vector3(Random.Range(-1000f, 1000f), -163f, Random.Range(-1000f, 1000f)), rotation);
        }

    }
}
