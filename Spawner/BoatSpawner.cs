using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public static BoatSpawner instance;

    public GameObject boatPref;

    int randRot;

    bool wait;
    WaitForSeconds twentySec = new WaitForSeconds(20f);
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(BoatMaker());
    }

    void FixedUpdate()
    {
        if(!wait) StartCoroutine(BoatMaker());
    }

    IEnumerator BoatMaker()
    {
        wait = true;
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);
        
        GameObject ob = Instantiate(boatPref, new Vector3(Random.Range(-930f, 930f), 110, Random.Range(-930f, 930f)), rotation);
        yield return twentySec;
        wait = false;
    }
}
