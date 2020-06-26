using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Server_Database;


public class SignupScript : MonoBehaviour
{
    public InputField loginText, paswwordText, verifPasswordText;
    public Button submit;

    private void Awake()
    {
        submit.onClick.AddListener(addUser);

    }

    public void addUser()
    {
        string login = loginText.text;
        string password = paswwordText.text;
        string verifPassword = verifPasswordText.text;

        if (login == "" || login == null || password == "" || password == null)
        {
            Debug.LogWarning("Aucun nom d'utilisateur ou de mot de passe");
        }
        else if(GetServer_UserIdFromEmail(login) != 0)
        {
            Debug.LogWarning("Utilisateur déja existant");
        }
        else if(password != verifPassword)
        {
            Debug.LogWarning("Les mots de passes sont différents");
        }
        else
        {
            Server_Database.AddNewServer_User(login, password);
            SceneManager.LoadScene("MenuLoginScene", LoadSceneMode.Single);
        }
    }

}
