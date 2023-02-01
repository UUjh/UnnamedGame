using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishes : MonoBehaviour
{
    public static Fishes instance;

    CharacterController fishCharCtrl;

    float randScale;
    float randRot;
    float moveSpeed;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        fishCharCtrl = GetComponent<CharacterController>();
        moveSpeed = Random.Range(0.05f, 0.2f);
        randScale = Random.Range(0.1f, 4f);
        gameObject.transform.localScale = new Vector3(randScale, randScale, randScale);

    }

    void Update()
    {
        fishCharCtrl.Move(transform.TransformDirection(new Vector3(0, 0, moveSpeed)));
        if (transform.position.x < -930 || transform.position.x > 930 || transform.position.z < -930 || transform.position.z > 930)
        {

            Destroy(gameObject);
            Debug.Log("물고기 사라짐");
        }

    }


}
