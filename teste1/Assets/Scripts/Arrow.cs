using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed); // faz com que o objeto siga para a direita com a velocidade speed

        Invoke(nameof(Morte), 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        Bow.instance.ArcoLongo();

        if (Bow.instance.acerto >= health.shield)
        {
            health.health -= Bow.instance.damage;

            Bow.instance.DamageIndicator.text = "Dano: " + Bow.instance.damage;
            Destroy(gameObject);
            health.ZeroHealth();
        }
        else
        {
            Bow.instance.DamageIndicator.text = "Errou";
        }
    }

    private void Morte()
    {
        Bow.instance.DamageIndicator.text = "Errou";
        Destroy(gameObject);
    }
}
