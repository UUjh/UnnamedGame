using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtles : MonoBehaviour
{
    public static Turtles instance;

    CharacterController turtleCharCtrl;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        turtleCharCtrl = GetComponent<CharacterController>();
        GetComponentInChildren<MeshCollider>();
        GetComponent<BoxCollider>();
    }

    void Update()
    {
        turtleCharCtrl.Move(transform.TransformDirection(new Vector3(0, 0, 0.1f)));

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Debug.Log("∞≈∫œ¿Ã ªÁ∂Û¡¸");
        }
    }
}
