using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Atributos : MonoBehaviour
{
    public int pontos;

    public int forca;
    public int destreza;
    public int constituicao;
    public int inteligencia;
    public int sabedoria;
    public int carisma;

    public int proficiencia;

    public int atletismo;
    public int diplomacia;
    public int furtividade;
    public int intimidacao;

    public int mod;

    public static Atributos instance;

    private void Start()
    {
        instance = this;

        atletismo = forca + proficiencia;
        diplomacia = carisma + proficiencia;
        furtividade= destreza + proficiencia;
        intimidacao = carisma + proficiencia;
    }

    private void Update()
    {
        Defesa();
        ProficienciaEditor();
    }

    public void Defesa()
    {
        Player.instance.shield = 10 + Modificador(destreza) + proficiencia;
    }

    public int Modificador(int atb)
    {
        if (atb == 1)
        {
            mod = -5;
        }
        else if (atb == 2 || atb == 3)
        {
            mod = -4;
        }
        else if (atb == 4 || atb == 5)
        {
            mod = -3;
        }
        else if (atb == 6 || atb == 7)
        {
            mod = -2;
        }
        else if (atb == 8 || atb == 9)
        {
            mod = -1;
        }
        else if (atb == 10 || atb == 11)
        {
            mod = 0;
        }
        else if (atb == 12 || atb == 13)
        {
            mod = 1;
        }
        else if (atb == 14 || atb == 15)
        {
            mod = 2;
        }
        else if (atb == 16 || atb == 17)
        {
            mod = 3;
        }
        else if (atb == 18 || atb == 19)
        {
            mod = 4;
        }
        else if (atb == 20 || atb == 21)
        {
            mod = 5;
        }
        else if (atb == 22 || atb == 23)
        {
            mod = 6;
        }
        else if (atb == 24 || atb == 25)
        {
            mod = 7;
        }
        else if (atb == 26 || atb == 27)
        {
            mod = 8;
        }
        else if (atb == 28 || atb == 29)
        {
            mod = 9;
        }
        else if (atb >= 30)
        {
            mod = 10;
        }

        return (mod);
    }

    private void ProficienciaEditor()
    {
        if (GameController.instance.life > 0 && GameController.instance.level < 5)
        {
            proficiencia = 2;
        }
        else if (GameController.instance.life > 4 && GameController.instance.level < 9)
        {
            proficiencia = 3;
        }
        else if (GameController.instance.life > 8 && GameController.instance.level < 13)
        {
            proficiencia = 4;
        }
        else if (GameController.instance.life > 12 && GameController.instance.level < 17)
        {
            proficiencia = 5;
        }
        else if (GameController.instance.life > 16)
        {
            proficiencia = 6;
        }
    }
}
