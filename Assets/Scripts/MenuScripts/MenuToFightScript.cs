using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuToFightScript : MonoBehaviour
{
    public void NavigationFight()
    {
        SceneManager.LoadScene("Arena", LoadSceneMode.Single);
    }
}
