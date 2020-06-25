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

    public void addUser()//lui donner le meme id que le user_player 1 pour lui associer un robot directement ni vu ni connu
    {
        string login = loginText.text;
        string password = paswwordText.text;
        string verifPassword = verifPasswordText.text;

        if(GetServer_UserIdFromEmail(login) != 0)
        {
            Debug.LogWarning("user déja existant");
        }

        if(password != verifPassword)
        {
            Debug.LogWarning("Les mots de passes sont différents");
        }

        //
        //méthode pour ajouter l'user a la bdd
        //

        SceneManager.LoadScene("MenuLoginScene", LoadSceneMode.Single);

    }

}
