using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Server_Database;



public class InputControlScript : MonoBehaviour
{
    [SerializeField] InputField emailField, passwordField; //on assigne les variables aux InputFields
    [SerializeField] Button btnLogin; //on assignela variable au bouton login
    string emailInput, passwordInput;
    int id_user;

    void Awake()
    {
        btnLogin.onClick.AddListener(Search); //écoute d'évennement onClick sur le bouton pour appeler la fonction Search()
    }

    public void Search()
    {
        emailInput = emailField.text; //prend la valeur entrée dans InputFieldEmail
        passwordInput = passwordField.text; //prend la valeur entrée dans InputFieldPassword

        id_user = GetServer_UserIdFromEmail(emailInput);


        if(CheckServer_UserPasswordFromUserId(id_user, passwordInput) == true ) //si authentification reussie
        {
            if(Server_Database.GetServer_UserAccountTypeFromUserId(id_user) == AccountTypeEnum.Player)
            {
                Game.SetCurentUser_Player(Server_Database.CreateUser_PlayerFromServer(GetServer_UserFromId(id_user)));
                //User_Player loc_player = (User_Player)Game.GetCurentUser();
                //Debug.Log(loc_player.GetUserRobot().GetStatSpeed());
                //Debug.Log(loc_player.GetEnemyRobot().GetStatSpeed());
                NavigationMenu("MenuMainScene");       //navigation vers le menu
            }

            if (Server_Database.GetServer_UserAccountTypeFromUserId(id_user) == AccountTypeEnum.Developper)
            {
                Game.SetCurentUser_Developper(Server_Database.CreateUser_DevelopperFromServer(GetServer_UserFromId(id_user)));
                //NavigationMenu();       //navigation vers le menu developpeur
            }

        }
        else
        {
            Debug.LogWarning("Email or password incorrect !");
        }

    }

    public void NavigationMenu(string arg_sceneName)
    {
        SceneManager.LoadScene(arg_sceneName, LoadSceneMode.Single); //navigation vers l'écran menu
    }
}