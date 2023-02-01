using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player instance;

    CharacterController charCtrl;
    Animator anim;
    Rigidbody whaleRb;

    public GameObject whale;
    
    public GameObject say;
    public GameObject crown;

    public ParticleSystem eatEffect;

    public float distance;



    //float speed = 50;
    float viewX;
    float viewY;
    float gravityPower = 5;
    //float upPower = 5;

    float size;

    private float health;
    private float oxygen;

    private float moveSpeed;
    float maxSpeed = 50f;

    private bool isDead;

    public float timer;

    Vector3 move;
    Vector3 gravity;
    Vector3 up;

    string currentPlayer;
    string bestPlayer;
    public int currentScore;
    int bestScore;

    float mouseY;
    float mouseX;

    public int ateFishes;
    int level;
    int exp;
    int maxExp;


    public float Health
    {
        get;
        set;
    }
    public float Oxygen
    {
        get;
        set;
    }
    public bool IsDead
    {
        get;set;
    }
    public float MoveSpeed
    {
        get;
        set;
    }

    public int Exp
    {
        get;set;
    }
    public int MaxExp
    {
        get;set;
    }
    
    public int Level
    {
        get;set;
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        crown.SetActive(false);

        size = 1;
        charCtrl = GetComponent<CharacterController>();
        //GetComponentInChildren<MeshCollider>();
        //GetComponent<BoxCollider>();
        whaleRb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        Health = 100f;
        Oxygen = 100f;
        IsDead = false;
        timer = 0f;
        
        whaleRb.useGravity = false;

        currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
        bestPlayer = PlayerPrefs.GetString("BestPlayer");
        bestScore = PlayerPrefs.GetInt("BestScore");

        Exp = 0;
        Level = 1;
        MaxExp = 5;

    }


    void Update()
    {
        if (!IsDead)
        {
            WhaleMove();
            Viewing();
            WhaleAnim();
            WhaleLife();
            timer += Time.deltaTime;
            Debug.Log(transform.localScale);
            if(Exp >= MaxExp)
            {
                LevelUp();
            }
            if (Level >= 15) crown.SetActive(true);
        }
        if (IsDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("Title");
            }
        }

    }

    #region 이동 주석
    //void WhaleMove()
    //{
    //    moveX = Input.GetAxis("Horizontal");
    //    moveZ = Input.GetAxis("Vertical");
    //    move = new Vector3(moveX, 0, moveZ);
    //    gravity = new Vector3(0, -gravityPower, 0);
    //    charCtrl.Move(transform.TransformDirection(move) * Time.deltaTime * speed);

    //    if (move.sqrMagnitude < 0.1)
    //    {
    //        Debug.Log("속도 낮음");
    //        charCtrl.Move(transform.TransformDirection(gravity) * Time.deltaTime);

    //    }

    //    if (transform.position.y > 125)
    //    {
    //        Debug.Log("제일 높음");
    //        charCtrl.Move(transform.TransformDirection(gravity) * 30 * Time.deltaTime);
    //    }

    //    if (transform.position.y < -573)
    //    {
    //        Debug.Log("제일 낮음");
    //        up = new Vector3(0, upPower, 0);
    //        charCtrl.Move(transform.TransformDirection(up) * 30 * Time.deltaTime);
    //    }
    //}
    #endregion

    void WhaleMove()
    {
        MoveSpeed -= Time.deltaTime * 12;
        if (MoveSpeed < 0) MoveSpeed = 0;
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.B))
        {
            MoveSpeed += 1f;
        }
        if (MoveSpeed >= maxSpeed)
        {
            MoveSpeed = maxSpeed;
        }
        //Debug.Log("MoveSpeed: " + MoveSpeed);


        move = new Vector3(0, 0, MoveSpeed);


        charCtrl.Move(transform.TransformDirection(move) * Time.deltaTime);
        if (MoveSpeed < 0.3f)
        {
            gravity = new Vector3(0, -gravityPower, 0);
            charCtrl.Move(transform.TransformDirection(gravity) * Time.deltaTime);
        }
        if (transform.position.y > 125f)
        {
            charCtrl.Move(transform.TransformDirection(gravity) * 30 * Time.deltaTime);
        }
    }

    void WhaleLife()
    {
        Health -= Time.deltaTime * 1.3f;

        Oxygen -= Time.deltaTime;
        if (transform.position.y > 123)
        {
            Oxygen += 100 * Time.deltaTime;
        }
        if (Oxygen > 100) Oxygen = 100f;
        if (Health > 100) Health = 100;

        if (Oxygen < 0 || Health < 0) WhaleDead();

    }

    void Viewing()
    {

        viewX += Input.GetAxis("Horizontal") * 0.5f;
        viewY += Input.GetAxis("Vertical") * 0.5f;
        viewY = Mathf.Clamp(viewY, -65.0f, 65.0f);
        transform.localEulerAngles = new Vector3(-viewY, viewX, 0);
    }
    //void MouseViewing()
    //{

    //    mouseX += Input.GetAxis("Mouse X");
    //    mouseY += Input.GetAxis("Mouse Y");
    //    mouseY = Mathf.Clamp(mouseY, -65.0f, 65.0f);
    //    transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);
    //}

    void WhaleAnim()
    {
        if (MoveSpeed != 0) {
            anim.SetFloat("moveSpeed", MoveSpeed * 0.1f);
        }

        if (transform.rotation.x < -0.3 || transform.rotation.x > 0.3)
        {
            anim.SetBool("Swim2", true);
            Debug.Log("위,아래");

        }
        else anim.SetBool("Swim2", false);
        if (MoveSpeed <= 0f) anim.StartPlayback();
        else anim.StopPlayback();

    }
    void LevelUp()
    {
        Exp = 0;
        size += 1f;
        whale.transform.DOScale(size, 0.5f);
        MaxExp += 1;
        Level++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");
        if (collision.gameObject.CompareTag("Fish"))
        {
            anim.Play("Attack");

            Exp++;

            Destroy(collision.gameObject);
            if (Health < 100) Health += 15;
            eatEffect.Play();
        }
        if (collision.gameObject.CompareTag("Shark"))
        {
            Debug.Log("Shark");
            if (Level < 8)
            {
                WhaleDead();

            }
            else
            {
                eatEffect.Play();
                Destroy(collision.gameObject);
                Exp += 50;
                Health += 50;
            }
        }

        if (collision.gameObject.CompareTag("Boat"))
        {
            if(Level < 15) WhaleDead();
            else
            {
                eatEffect.Play();
                Destroy(collision.gameObject);
                Exp += 150;
                Health += 100;
            }
        }

        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    say.SetActive(true);
        //    Oxygen -= Time.deltaTime * 5f;

        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            say.SetActive(true);
            //Oxygen -= Time.deltaTime * 5f;
        }
        else
        {
            say.SetActive(false);
        }
    }



    void WhaleDead()
    {
        Debug.Log("Dead");
        IsDead = true;
        anim.StartPlayback();

        gravity = new Vector3(0, -gravityPower*10, 0);
        
        charCtrl.Move(transform.TransformDirection(gravity) * Time.deltaTime);
        whaleRb.useGravity = true;


        currentScore = (int)timer;
        if (currentScore > bestScore) 
        {
            //PlayerPrefs.SetInt("BestScore", currentScore);
            //PlayerPrefs.SetString("BestPlayer", currentPlayer);
            DataManager.instance.BestScoreSave();
        }
    }

    void Restart()
    {
        Exp = 0;
        Level = 1;
        MaxExp = 5;
        MoveSpeed = 0f;

        size = 1f;
        whale.transform.DOScale(1f, 0f);

        IsDead = false;
        Health = 100f;
        Oxygen = 100f;
        whaleRb.useGravity = false;
        timer = 0f;

        this.transform.position = new Vector3(0, 0, 0);
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestPlayer = PlayerPrefs.GetString("BestPlayer");
        crown.SetActive(false);

    }
}
