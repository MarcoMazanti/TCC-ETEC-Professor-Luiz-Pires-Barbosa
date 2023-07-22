using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int point;

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        circle = GetComponent<CircleCollider2D> ();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalPoint += point;
            GameController.instance.AtualizacaoPontuacao();

            Destroy(gameObject, 0.35f);
        }
    }
}
