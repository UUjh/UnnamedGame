using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sharks : MonoBehaviour
{
    public static Sharks instance;

    GameObject targetob;
    Transform target;

    CharacterController sharkCharCtrl;

    public float distance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        targetob = GameObject.Find("Player");
        target = targetob.transform;
        sharkCharCtrl = GetComponent<CharacterController>();

    }

    void Update()
    {
        sharkCharCtrl.Move(transform.TransformDirection(new Vector3(0, 0, 0.1f)));

        float distance = Vector3.Distance(target.position, transform.position);
        if(Player.instance.Level < 8) findPlayer();

        if (transform.position.x < -930 || transform.position.x > 930 || transform.position.z < -930 || transform.position.z > 930)
        {
            Destroy(gameObject);
            Debug.Log("»ó¾î »ç¶óÁü");
        }
    }


    void findPlayer()
    {
        distance = (target.position - transform.position).sqrMagnitude;

        if (Player.instance.IsDead == false && distance <= 40000)
        {
            Debug.Log("Detection Target!");
            transform.LookAt(target);
            Vector3 targetPos = new Vector3(target.position.x, target.position.y - 20f, target.position.z -25f);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.2f);
        }
    }

}
