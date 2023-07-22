using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public float speed;
    public int damage;
    public float distanceToAtack;

    [SerializeField] private float delay;

    [SerializeField] private Transform pointAtack;
    [SerializeField] private LayerMask filter;

    private float nextAtack;

    private Animator animator;
    private Transform jogador;

    public static Enemie instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        animator= GetComponent<Animator>();

        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Atack();
    }

    private void OnDrawGizmos()
    {
        if (pointAtack != null)
        {
            Gizmos.DrawWireSphere(pointAtack.position, distanceToAtack);
        }
    }

    private void Atack() // vai seguir o jogador
    {
        if (jogador != null)
        {
            Collider2D collider = Physics2D.OverlapCircle(pointAtack.position, distanceToAtack, filter);
            if (collider != null)
            {
                Player player = collider.gameObject.GetComponent<Player>();
                if (player != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, jogador.position, speed * Time.deltaTime);
                    if (transform.position.x > jogador.position.x)
                    {
                        animator.SetBool("isRight", false);
                        animator.SetBool("isLeft", true);
                    }
                    else
                    {
                        animator.SetBool("isRight", true);
                        animator.SetBool("isLeft", false);
                    }
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision) // vai dar o dano no jogador
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > nextAtack && damage > Player.instance.shield)
            {
                Player.instance.life -= damage;

                Delay();
            }
        }
    }

    void Delay()
    {
        nextAtack = Time.time + delay;
    }
}
