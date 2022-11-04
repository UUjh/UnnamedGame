using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurtleSpawner : MonoBehaviour
{
    public static TurtleSpawner instance;

    public GameObject turtlePref;

    private float spawnTime = 60f;
    private float lastSpawn;
    int randRot;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 3; i++) TurtleMaker();
        lastSpawn = 0;
    }

    void Update()
    {
        lastSpawn += Time.deltaTime;
        if (lastSpawn > spawnTime)
        {
            lastSpawn = 0;
            TurtleMaker();
        }
    }

    void TurtleMaker()
    {
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);
        GameObject ob = Instantiate(turtlePref, new Vector3(Random.Range(-1000f, 1000f), -163f, Random.Range(-1000f, 1000f)), rotation);
    }
}
