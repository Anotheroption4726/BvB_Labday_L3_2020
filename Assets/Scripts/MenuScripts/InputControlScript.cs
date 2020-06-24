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
    //Server_User[] serverUserTable;

    void Awake()
    {
        btnLogin.onClick.AddListener(Search); //écoute d'évennement onClick sur le bouton pour appeler la fonction Search()

        //serverUserTable = Server_Database.GetUsersTable();
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
                Debug.LogWarning("utilisateur player authentifié");
                Game.SetCurentUser_Player(Server_Database.CreateUser_PlayerFromServer(GetServer_UserFromId(id_user)));
                NavigationMenu();       //navigation vers le menu
            }

            if (Server_Database.GetServer_UserAccountTypeFromUserId(id_user) == AccountTypeEnum.Developper)
            {
                Debug.LogWarning("utilisateur developper authentifié");
                Game.SetCurentUser_Developper(Server_Database.CreateUser_DevelopperFromServer(GetServer_UserFromId(id_user)));
                //NavigationMenu();       //navigation vers le menu developpeur
            }

        }
        else
        {
            Debug.LogWarning("Email or password incorrect !");
        }

    }

    public void NavigationMenu()
    {
        SceneManager.LoadScene("MenuMainScene", LoadSceneMode.Single); //navigation vers l'écran menu
    }
}