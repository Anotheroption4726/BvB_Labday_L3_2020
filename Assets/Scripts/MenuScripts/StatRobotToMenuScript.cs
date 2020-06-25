using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatRobotToMenuScript : MonoBehaviour
{
    public void NavigationMenu()
    {
        User_Player loc_player = (User_Player)Game.GetCurentUser();
        //Server_Database.SetServer_Robot_PlayerFromUserId(loc_player.GetId(), Server_Robot_Player arg_serverRobot, loc_player.GetToken());
        SceneManager.LoadScene("MenuMainScene", LoadSceneMode.Single);
    }
}
 