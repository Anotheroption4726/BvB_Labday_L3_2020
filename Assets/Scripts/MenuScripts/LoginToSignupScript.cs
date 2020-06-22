using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginToSignupScript : MonoBehaviour
{
    public void NavigationSignup()
    {
        SceneManager.LoadScene("MenuNewUserScene", LoadSceneMode.Single);
    }
}
