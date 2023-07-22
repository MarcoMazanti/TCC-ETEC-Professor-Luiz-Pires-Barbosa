using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public string texto1;
    public string texto2;
    public Text text1;
    public Text text2;
    public GameObject placa;

    // Start is called before the first frame update
    void Start()
    {
        text1.text = texto1;
        text2.text = texto2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            placa.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            placa.SetActive(false);
        }
    }
}
