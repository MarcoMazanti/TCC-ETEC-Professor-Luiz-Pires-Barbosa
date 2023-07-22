using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Animal : MonoBehaviour
{
    [SerializeField] private float speed;

    private float speedHorizontal;
    private float speedVertical;
    private Vector2 x, y;

    private System.Random rand = new System.Random();

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        speedHorizontal = speed;
        speedVertical = speed;

        x = Vector2.right;
        y = Vector2.up;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(x * speedHorizontal * Time.deltaTime);
        transform.Translate(y * speedVertical * Time.deltaTime);

        if (speedHorizontal < 0)
        {
            anim.SetBool("isRight", false);
        }
        else
        {
            anim.SetBool("isRight", true);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "objeto" || collision.gameObject.tag == "Player" || collision.gameObject.layer == 0 || collision.gameObject.tag == "animal")
        {
            int supX = rand.Next(1, 3);
            int supY = rand.Next(1, 3);

            if (supX == 1)
            {
                speedHorizontal = speedHorizontal * (-1);
            }
            if (supY == 1)
            {
                speedVertical = speedVertical * (-1);
            }
        }
    }
}
