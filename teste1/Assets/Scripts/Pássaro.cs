using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Pássaro : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float direction;

    private float x, y;
    private float totalSpeed;

    [SerializeField] private float xp;

    // Start is called before the first frame update
    void Start()
    {
        totalSpeed = speed * Time.deltaTime;
        transform.Rotate(0f, 0f, direction);
        x = (1.414f / 2f) * totalSpeed;
        y = x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = new(x, y, 0f); // é um vector3 simplificado
        transform.position += movement * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            switch (collision.gameObject.name) // vira o pássaro quando bate em um dos cantos
            {
                case "LimiteRight":
                    transform.Rotate(0f, 0f, 90f);
                    x = -x;
                    break;
                case "LimiteLeft":
                    transform.Rotate(0f, 0f, -270f);
                    x = -x;
                    break;
                case "LimiteUp":
                    transform.Rotate(0f, 0f, 90f);
                    y = -y;
                    break;
                case "LimiteDown":
                    transform.Rotate(0f, 0f, 90f);
                    y = -y;
                    break;
            }
        }
    }
}
