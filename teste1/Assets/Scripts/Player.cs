using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float totalLife;
    public int shield;
    public float delay;
    public float xp;
    public float life;

    public static Player instance;
    public GameObject deadEffect;
    public GameObject sword;
    public GameObject bow;

    private Animator anim;

    public GameObject mainCamera;
    public GameObject canvas;
    public GameObject gameControl;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(mainCamera);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameControl);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();

        life = totalLife;

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (life <= 0) // sistema de morte
        {
            deadEffect.SetActive(true);
            GameObject.Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1)) // troca para a espada
        {
            sword.SetActive(true);
            bow.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2)) // troca para o arco
        {
            sword.SetActive(false);
            bow.SetActive(true);
        }
    }

    private void Move() // sistema para as animações de movimento funcionarem
    {
        Vector3 movement = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += speed * Time.deltaTime * movement;

        if (movement.x < 0f) // para esquerda
        {
            anim.SetBool("isRight",false);
            anim.SetBool("isLeft", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }

        if (movement.x > 0f) // para direita
        {
            anim.SetBool("isRight", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }

        if (movement.y < 0f)
        {
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", true);
        }

        if (movement.y > 0f)
        {
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp",true);
            anim.SetBool("isDown", false);
        }

        if (movement.x == 0f && movement.y == 0f) // parado
        {
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }
    }
}
