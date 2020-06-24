using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatRobotToMenuScript : MonoBehaviour
{
    public void NavigationMenu()
    {
        SceneManager.LoadScene("MenuMainScene", LoadSceneMode.Single);
    }
}
