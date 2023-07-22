using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    private System.Random rand = new System.Random();

    private float nextAtack;
    private int damage;
    private int acerto;

    [SerializeField] private float radAtack;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Text DamageIndicator;

    [SerializeField] private Transform pointAtack1;
    [SerializeField] private Transform pointAtack2;
    private SpriteRenderer sprite;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        ATack();
    }

    private void Aim() // aponta o objeto para o mouse
    {
        Vector3 mousePoint = Input.mousePosition; // pega a posição do mouse na tela
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position); // pega a posição da arma

        Vector2 offset = new Vector2(mousePoint.x - screenPoint.x, mousePoint.y - screenPoint.y); // calcula a distancia entre eles no eixo x e no eixo y

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; // calcula angulo em raidanos e depois transforma em graus

        transform.rotation = Quaternion.Euler(0, 0, angle - 90); // vai rotacionar a imagem
    }

    private void Delay()
    {
        nextAtack = Time.time + Player.instance.delay;
    }

    private void OnDrawGizmos()
    {
        if (pointAtack1 != null && pointAtack2 != null)
        {
            Gizmos.DrawWireSphere(pointAtack1.position, radAtack); // desenha um circulo na tela de teste
            Gizmos.DrawWireSphere(pointAtack2.position, radAtack);
        }
    }

    private void ATack()
    {
        Collider2D collider1 = Physics2D.OverlapCircle(pointAtack1.position, radAtack, layerMask); // cria um circulo na tela e atribui na variavel collider1 o primeiro objeto encontrado
        Collider2D collider2 = Physics2D.OverlapCircle(pointAtack2.position, radAtack, layerMask);

        if (collider1 != null && collider2 != null)
        {
            Health health1 = collider1.GetComponent<Health>();
            Health health2 = collider2.GetComponent<Health>();

            if (Input.GetButtonDown("Fire1") && Time.time > nextAtack)
            {
                acerto = rand.Next(1, 20) + Atributos.instance.forca + Atributos.instance.proficiencia;
                damage = rand.Next(1, 8) + Atributos.instance.forca;

                if (acerto >= health1.shield || acerto >= health2.shield)
                {
                    if (health1 != null)
                    {
                        if (health1.shield < acerto)
                        {
                            health1.health -= damage;

                            health1.ZeroHealth();
                        }
                        AtackAnim();
                    }
                    if (health2 != null)
                    {
                        if (health2.shield < acerto)
                        {
                            health2.health -= damage;

                            health2.ZeroHealth();
                        }
                        AtackAnim();
                    }

                    DamageIndicator.text = "Dano: " + damage.ToString();
                }
                else
                {
                    DamageIndicator.text = "Errou";
                }
            }  
        }
        
    }

    private void AtackingOff()
    {
        anim.SetBool("isAtacking", false);
    }

    private void AtackAnim()
    {
        anim.SetBool("isAtacking", true);
        Invoke(nameof(AtackingOff), 0.5f); // chama a classe depois de um tempo
        Delay();
    }
}
