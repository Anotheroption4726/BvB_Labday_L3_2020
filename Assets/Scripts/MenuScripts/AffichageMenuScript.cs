using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

//using static Server_Database;

public class AffichageMenuScript : MonoBehaviour
{
    public Text pseudo , attack, life, speed, agility, aggressivity, nbWins, nbGames; //on assigne les variables aux champs texte
    public Button muteBtn;

    void Awake()
    {
        int games = Server_Database.GetServer_UserWinsFromUserId(Game.GetCurentUser().GetId()) + Server_Database.GetServer_UserLossesFromUserId(Game.GetCurentUser().GetId()); //nombre de wins + nombre de losses

        User_Player loc_player = (User_Player)Game.GetCurentUser();
        pseudo.text = Game.GetCurentUser().GetName();
        attack.text = (loc_player.GetUserRobot().GetStatAttack()).ToString();
        life.text = (loc_player.GetUserRobot().GetStatHp()).ToString();
        speed.text = (loc_player.GetUserRobot().GetStatSpeed()).ToString();
        agility.text = (loc_player.GetUserRobot().GetBehaviorAgility()).ToString();
        aggressivity.text = (loc_player.GetUserRobot().GetBehaviorAggressivity()).ToString();

        nbWins.text = (Server_Database.GetServer_UserWinsFromUserId(Game.GetCurentUser().GetId())).ToString();
        nbGames.text = games.ToString();
    }

    public void mute()
    {
        if(Game.GetMuteAudio() == true)
        {
            Game.SetMuteAudio(false);
            Debug.Log("mute off");
        }
        else
        {
            Game.SetMuteAudio(true);
            Debug.Log("mute on");

        }
    }

    public void deconnexion()
    {
        Game.ClearCurentSession();
        SceneManager.LoadScene("MenuLoginScene", LoadSceneMode.Single);
    }

}
