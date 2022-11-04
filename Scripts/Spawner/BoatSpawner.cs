using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public static BoatSpawner instance;

    public GameObject boatPref;

    private float spawnTime = 20f;
    private float lastSpawn;
    int randRot;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        BoatMaker(); 

        lastSpawn = 0;
    }

    void Update()
    {

        lastSpawn += Time.deltaTime;
        if (lastSpawn > spawnTime)
        {
            lastSpawn = 0;
            BoatMaker();
        }
    }

    void BoatMaker()
    {

        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);
        
        GameObject ob = Instantiate(boatPref, new Vector3(Random.Range(-930f, 930f), 110, Random.Range(-930f, 930f)), rotation);
                

    }
}
