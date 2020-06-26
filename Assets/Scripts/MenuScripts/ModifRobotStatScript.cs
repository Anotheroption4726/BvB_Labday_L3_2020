using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModifRobotStatScript : MonoBehaviour
{
    public Text pseudo, attack, life, speed, agility, aggressivity; //on assigne les variables aux champs texte
    public Text pointsATK, pointsHP, pointsSPEED, pointsAGI, pointsAGGR; //valeurs modifiactions de stats
    public Button atkMoins, atkPlus, hpMoins, hpPlus, speedMoins, speedPlus, agiMoins, agiPlus, aggrMoins, aggrPlus; //boutons pour modifier les stats
    public Button precedentWeapon, nextWeapon; //boutons choix d'arme
    public Text weaponName; //nom de l'arme

    User_Player loc_player = (User_Player)Game.GetCurentUser();


    void Awake()
    {
        pseudo.text = Game.GetCurentUser().GetName();
        attack.text = (loc_player.GetUserRobot().GetStatAttack()).ToString();
        life.text = (loc_player.GetUserRobot().GetStatHp()).ToString();
        speed.text = (loc_player.GetUserRobot().GetStatSpeed()).ToString();
        agility.text = (loc_player.GetUserRobot().GetBehaviorAgility()).ToString();
        aggressivity.text = (loc_player.GetUserRobot().GetBehaviorAggressivity()).ToString();


        weaponName.text = Game.GetWeaponFromId(loc_player.GetUserRobot().GetWeaponId()).GetName();

        pointsATK.text = attack.text;
        pointsHP.text = life.text;
        pointsSPEED.text = speed.text;
        pointsAGI.text = agility.text;
        pointsAGGR.text = aggressivity.text;

        atkPlus.onClick.AddListener(AttackPlus);
        atkMoins.onClick.AddListener(AttackMoins);
        hpMoins.onClick.AddListener(LifeMoins);
        hpPlus.onClick.AddListener(LifePlus);
        speedPlus.onClick.AddListener(SpeedPlus);
        speedMoins.onClick.AddListener(SpeedMoins);
        agiPlus.onClick.AddListener(AgilityPlus);
        agiMoins.onClick.AddListener(AgilityMoins);
        aggrPlus.onClick.AddListener(AggressivityPlus);
        aggrMoins.onClick.AddListener(AggressivityMoins);

        precedentWeapon.onClick.AddListener(PreWeapon);
        nextWeapon.onClick.AddListener(NextWeapon);

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

    public void AgilityPlus()
    {
        if (loc_player.GetUserRobot().GetBehaviorAgility() < 100)
        {
            loc_player.GetUserRobot().SetBehaviorAgility(loc_player.GetUserRobot().GetBehaviorAgility() + 10);
            agility.text = (loc_player.GetUserRobot().GetBehaviorAgility()).ToString();
            pointsAGI.text = agility.text;
        }
    }

    public void AgilityMoins()
    {
        if (loc_player.GetUserRobot().GetBehaviorAgility() > 0)
        {
            loc_player.GetUserRobot().SetBehaviorAgility(loc_player.GetUserRobot().GetBehaviorAgility() - 10);
            agility.text = (loc_player.GetUserRobot().GetBehaviorAgility()).ToString();
            pointsAGI.text = agility.text;
        }
    }

    public void AggressivityPlus()
    {
        if (loc_player.GetUserRobot().GetBehaviorAggressivity() < 100)
        {
            loc_player.GetUserRobot().SetBehaviorAggressivity(loc_player.GetUserRobot().GetBehaviorAggressivity() + 10);
            aggressivity.text = (loc_player.GetUserRobot().GetBehaviorAggressivity()).ToString();
            pointsAGGR.text = aggressivity.text;
        }
    }

    public void AggressivityMoins()
    {
        if (loc_player.GetUserRobot().GetBehaviorAggressivity() > 0)
        {
            loc_player.GetUserRobot().SetBehaviorAggressivity(loc_player.GetUserRobot().GetBehaviorAggressivity() - 10);
            aggressivity.text = (loc_player.GetUserRobot().GetBehaviorAggressivity()).ToString();
            pointsAGGR.text = aggressivity.text;
        }
    }

    public void PreWeapon()
    {
        if(weaponName.text == "Weapon 2")
        {
            weaponName.text = "Weapon 1";
        }
    }

    public void NextWeapon()
    {
        if (weaponName.text == "Weapon 1")
        {
            weaponName.text = "Weapon 2";
        }
    }
}
