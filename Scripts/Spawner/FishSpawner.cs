using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public static FishSpawner instance;

    public GameObject fishPref;
    public GameObject fishPref1;
    public GameObject fishPref2;

    private float spawnTime = 1f;
    private float lastSpawn;
    int randRot;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 50; i++) FishMaker();
        lastSpawn = 0;
    }

    void Update()
    {
        lastSpawn += Time.deltaTime;
        if(lastSpawn > spawnTime)
        {
            lastSpawn = 0;
            FishMaker();
        }
    }

    void FishMaker()
    {
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);

        GameObject ob = Instantiate(fishPref, new Vector3(Random.Range(-1000f,1000f),Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
        GameObject ob1 = Instantiate(fishPref1, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
        GameObject ob2 = Instantiate(fishPref2, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
    }

}
