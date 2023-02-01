using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject stonePref;
    public GameObject stonePref1;
    public GameObject stonePref2;

    int randRot;


    void Start()
    {
        for (int i = 0; i < 5; i++) StoneMaker();
    }

    void StoneMaker()
    {
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);

        GameObject ob = Instantiate(stonePref, new Vector3(Random.Range(-1000f, 1000f), -170, Random.Range(-1000f, 1000f)), rotation);
        GameObject ob1 = Instantiate(stonePref1, new Vector3(Random.Range(-1000f, 1000f), -170, Random.Range(-1000f, 1000f)), rotation);
        GameObject ob2 = Instantiate(stonePref2, new Vector3(Random.Range(-1000f, 1000f), -170, Random.Range(-1000f, 1000f)), rotation);
    }
}
