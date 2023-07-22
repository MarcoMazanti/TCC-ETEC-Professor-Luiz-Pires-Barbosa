using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private System.Random rand = new System.Random();

    public int totalPoint;
    public Text textoPontuacao;

    public Text lifeText;
    public float life;
    public Image lifeImage;

    public Text textShield;
    public int shield;

    public Text xpIndicator;
    public Text levelUpdated;
    public GameObject levelUpdatedIcon;
    public Text xpPorcent;
    public Image xpImage;
    public int level = 1;
    private float nextLevel;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        levelUpdatedIcon.SetActive(false);

        XpNecessario();
    }

    private void Update()
    {
        shield = Player.instance.shield;
        life = Player.instance.life;

        Vida();
        Escudo();
        Xp();
    }

    public void AtualizacaoPontuacao()
    {
        textoPontuacao.text = totalPoint.ToString();
    }

    private void Vida()
    {
        lifeImage.fillAmount = Player.instance.life / Player.instance.totalLife;

        lifeText.text = Player.instance.life + " / " + Player.instance.totalLife;
    }

    private void Escudo()
    {
        
    }

    private void Xp()
    {
        if (Player.instance.xp >= nextLevel) // sistema para upar de level
        {
            level++;
            Player.instance.totalLife += rand.Next(1, 8) + Atributos.instance.Modificador(Atributos.instance.constituicao);
            XpNecessario();

            Atributos.instance.pontos += 5;
        }
        int updatLevel = Mathf.RoundToInt(nextLevel); // transforma o valor float em int
        int updateXp = Mathf.RoundToInt(Player.instance.xp);

        xpIndicator.text = "Nv." + level.ToString();
        xpPorcent.text = updateXp.ToString() + " / " + updatLevel.ToString();
        xpImage.fillAmount = Player.instance.xp / nextLevel;

        if (Atributos.instance.pontos != 0)
        {
            levelUpdatedIcon.SetActive(true);
            levelUpdated.text = xpIndicator.text;
        }
        else
        {
            levelUpdatedIcon.SetActive(false);
        }
    }

    private void XpNecessario()
    {
        switch (level)
        {
            case 1: // caso seja 1, vai precisar de 300 de xp para ir para o nivel 2
                nextLevel = 300;
                break;
            case 2:
                nextLevel = 900;
                break;
            case 3:
                nextLevel = 2700;
                break;
            case 4:
                nextLevel = 6500;
                break;
            case 5:
                nextLevel = 14000;
                break;
            case 6:
                nextLevel = 23000;
                break;
            case 7:
                nextLevel = 34000;
                break;
            case 8:
                nextLevel = 48000;
                break;
            case 9:
                nextLevel = 64000;
                break;
            case 10:
                nextLevel = 85000;
                break;
            case 11:
                nextLevel = 100000;
                break;
            case 12:
                nextLevel = 120000;
                break;
            case 13:
                nextLevel = 140000;
                break;
            case 14:
                nextLevel = 165000;
                break;
            case 15:
                nextLevel = 195000;
                break;
            case 16:
                nextLevel = 225000;
                break;
            case 17:
                nextLevel = 265000;
                break;
            case 18:
                nextLevel = 305000;
                break;
            case 19:
                nextLevel = 355000;
                break;
        }
    }
}
