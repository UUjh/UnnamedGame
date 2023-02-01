using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public static FishSpawner instance;

    public GameObject fishPref;
    public GameObject fishPref1;
    public GameObject fishPref2;

    bool wait;
    WaitForSeconds oneSec = new WaitForSeconds(1f);
    int randRot;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        FirstFishMaker();
    }

    void FixedUpdate()
    {
        if (!wait) StartCoroutine(FishMaker());
    }

    IEnumerator FishMaker()
    {
        wait = true;
        randRot = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0, randRot, 0);

        GameObject ob = Instantiate(fishPref, new Vector3(Random.Range(-1000f,1000f),Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
        GameObject ob1 = Instantiate(fishPref1, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
        GameObject ob2 = Instantiate(fishPref2, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);

        yield return oneSec;
        wait = false;
    }
    void FirstFishMaker()
    {
        for (int i = 0; i < 40; i++)
        {
            randRot = Random.Range(0, 360);
            Quaternion rotation = Quaternion.Euler(0, randRot, 0);

            GameObject ob = Instantiate(fishPref, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
            GameObject ob1 = Instantiate(fishPref1, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
            GameObject ob2 = Instantiate(fishPref2, new Vector3(Random.Range(-1000f, 1000f), Random.Range(-160f, 65f), Random.Range(-1000f, 1000f)), rotation);
        }
    }

}
