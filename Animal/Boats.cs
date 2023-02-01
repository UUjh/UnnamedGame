using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boats : MonoBehaviour
{
    public static Boats instance;

    CharacterController boatCharCtrl;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        boatCharCtrl = GetComponent<CharacterController>();
        //GetComponent<BoxCollider>();
    }

    void Update()
    {
        boatCharCtrl.Move(transform.TransformDirection(new Vector3(0, 0, 1f)));
        if(transform.position.x < -930 || transform.position.x > 930 || transform.position.z < -930 || transform.position.z > 930)
        {

            Destroy(gameObject);
            Debug.Log("º¸Æ® »ç¶óÁü");
        }
    }

}
