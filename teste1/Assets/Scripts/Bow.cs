using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    SpriteRenderer sprite;
    private System.Random rand = new System.Random();

    public int damage;
    public int acerto;

    public GameObject arrow;
    public Transform spawnArrow;
    public Text DamageIndicator;

    private Animator anim;

    private float nextAtack;

    public static Bow instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextAtack)
        {
            AtackAnim();
            Instantiate(arrow, spawnArrow.position, transform.rotation); // ele cria um "arrow" na posição "spawnArrow" e rotaciona ela
            Delay();
        }
    }

    private void Aim()
    {
        Vector3 mousePoint = Input.mousePosition; // pega a posição do mouse na tela
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position); // pega a posição da arma

        Vector2 offset = new Vector2(mousePoint.x - screenPoint.x, mousePoint.y - screenPoint.y); // calcula a distancia entre eles no eixo x e no eixo y

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; // calcula angulo em raidanos e depois transforma em graus

        transform.rotation = Quaternion.Euler(0, 0, angle); // vai girar a imagem

        sprite.flipY = (mousePoint.x < screenPoint.x); // se a condição for verdadeira, o flipY da imagem vai ser true, caso contrario vai ser false
    }

    private void Delay()
    {
        nextAtack = Time.time + Player.instance.delay;
    }

    public void ArcoLongo()
    {
        damage = rand.Next(1, 8) + Atributos.instance.forca;
        acerto = rand.Next(1, 20) + Atributos.instance.destreza + Atributos.instance.proficiencia;
    }

    private void AtackingOff()
    {
        anim.SetBool("isAtacking", false);
    }

    private void AtackAnim()
    {
        anim.SetBool("isAtacking", true);
        Invoke(nameof(AtackingOff), 1f); // chama a classe depois de um tempo
        Delay();
    }
}
