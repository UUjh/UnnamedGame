using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SharkSpawner : MonoBehaviour
{
    public static SharkSpawner instance;

    public GameObject sharkPref;

    private float spawnTime = 30f;
    private float lastSpawn;
    int randRot;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 3; i++) SharkMaker();
        lastSpawn = 0;
    }

    void Update()
    {
        lastSpawn += Time.deltaTime;
        if (lastSpawn > spawnTime)
        {
            lastSpawn = 0;
            SharkMaker();
        }
    }

    void SharkMaker()
    {
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);
        GameObject ob = Instantiate(sharkPref, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
    }
}
