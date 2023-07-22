using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int shield;
    public int xp;

    public static Health instance;

    private void Start()
    {
        instance = this;
    }

    public void ZeroHealth()
    {
        if (health <= 0)
        {
            Player.instance.xp += this.xp;
            Destroy(gameObject);
        }
    }
}
