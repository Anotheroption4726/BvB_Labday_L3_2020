using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

//using static Server_Database;

public class AffichageMenuScript : MonoBehaviour
{
    public Text pseudo , attack, life, speed; //on assigne les variables aux champs texte
    public Button muteBtn;

    void Awake()
    {
        User_Player loc_player = (User_Player)Game.GetCurentUser();
        pseudo.text = (Game.GetCurentUser().GetId()).ToString();
        attack.text = (loc_player.GetUserRobot().GetStatAttack()).ToString();
        life.text = (loc_player.GetUserRobot().GetStatHp()).ToString();
        speed.text = (loc_player.GetUserRobot().GetStatSpeed()).ToString();

    }

}
