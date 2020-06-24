using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModifRobotStatScript : MonoBehaviour
{
    public Text pseudo, attack, life, speed; //on assigne les variables aux champs texte
    public Text pointsATK, pointsHP, pointsSPEED; //valeurs modifiactions de stats
    public Button atkMoins, atkPlus, hpMoins, hpPlus, speedMoins, speedPlus; //boutons pour modifier les stats
    public Button precedentWeapon, nextWeapon; //boutons choix d'arme
    public Text weaponName; //nom de l'arme

    User_Player loc_player = (User_Player)Game.GetCurentUser();


    void Awake()
    {
        pseudo.text = (Game.GetCurentUser().GetId()).ToString();
        attack.text = (loc_player.GetUserRobot().GetStatAttack()).ToString();
        life.text = (loc_player.GetUserRobot().GetStatHp()).ToString();
        speed.text = (loc_player.GetUserRobot().GetStatSpeed()).ToString();

        weaponName.text = Game.GetWeaponFromId(loc_player.GetUserRobot().GetWeaponId()).GetName();

        pointsATK.text = attack.text;
        pointsHP.text = life.text;
        pointsSPEED.text = speed.text;

        atkPlus.onClick.AddListener(AttackPlus);
        atkMoins.onClick.AddListener(AttackMoins);
        hpMoins.onClick.AddListener(LifeMoins);
        hpPlus.onClick.AddListener(LifePlus);
        speedPlus.onClick.AddListener(SpeedPlus);
        speedMoins.onClick.AddListener(SpeedMoins);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackPlus()
    {
        if (loc_player.GetUserRobot().GetStatAttack()<100)
        {
            loc_player.GetUserRobot().SetStatAttack(loc_player.GetUserRobot().GetStatAttack() + 10);
            attack.text = (loc_player.GetUserRobot().GetStatAttack()).ToString();
            pointsATK.text = attack.text;
        }
        
    }

    public void AttackMoins()
    {
        if (loc_player.GetUserRobot().GetStatAttack() > 0)
        {
            loc_player.GetUserRobot().SetStatAttack(loc_player.GetUserRobot().GetStatAttack() - 10);
            attack.text = (loc_player.GetUserRobot().GetStatAttack()).ToString();
            pointsATK.text = attack.text;
        }
    }

    public void LifePlus()
    {
        if (loc_player.GetUserRobot().GetStatHp() < 100)
        {
            loc_player.GetUserRobot().SetStatHp(loc_player.GetUserRobot().GetStatHp() + 10);
            life.text = (loc_player.GetUserRobot().GetStatHp()).ToString();
            pointsHP.text = life.text;
        }
    }

    public void LifeMoins()
    {
        if (loc_player.GetUserRobot().GetStatHp() > 0)
        {
            loc_player.GetUserRobot().SetStatHp(loc_player.GetUserRobot().GetStatHp() - 10);
            life.text = (loc_player.GetUserRobot().GetStatHp()).ToString();
            pointsHP.text = life.text;
        }
    }

    public void SpeedPlus()
    {
        if (loc_player.GetUserRobot().GetStatSpeed() < 100)
        {
            loc_player.GetUserRobot().SetStatSpeed(loc_player.GetUserRobot().GetStatSpeed() + 10);
            speed.text = (loc_player.GetUserRobot().GetStatSpeed()).ToString();
            pointsSPEED.text = speed.text;
        }
    }

    public void SpeedMoins()
    {
        if (loc_player.GetUserRobot().GetStatSpeed() > 0)
        {
            loc_player.GetUserRobot().SetStatSpeed(loc_player.GetUserRobot().GetStatSpeed() - 10);
            speed.text = (loc_player.GetUserRobot().GetStatSpeed()).ToString();
            pointsSPEED.text = speed.text;
        }
    }
}
