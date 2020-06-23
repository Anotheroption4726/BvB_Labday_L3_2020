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
    string login = "test"; //login pour se connecter
    string password = "password"; //password pour se connecter

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

        Debug.Log("Email value: " + emailInput);
        Debug.Log("password value: " + passwordInput);
        if (emailInput == login && passwordInput == password) //si login et password corrects
        {
            NavigationMenu();
        }
        else
        {
            Debug.LogWarning("Email or password incorrect !");
        }

    }

    public void NavigationMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single); //navigation vers l'écran menu
    }
}