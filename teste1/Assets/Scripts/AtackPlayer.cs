using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
    [SerializeField] // faz com que possa ser mexida na unity mesmo sendo privada
    private float raioAtack;

    // são os pontos de referência das 8 direções
    [SerializeField]
    private Transform pointAtack;

    [SerializeField]
    private LayerMask layersAtack;

    [SerializeField]
    private Player player; // referencia o script jogador

    private float nextAtack;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
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
}
