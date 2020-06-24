using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToRobotStatScript : MonoBehaviour
{
    public void NavigationStat()
    {
        SceneManager.LoadScene("MenustatRobotScene", LoadSceneMode.Single);
    }
}
