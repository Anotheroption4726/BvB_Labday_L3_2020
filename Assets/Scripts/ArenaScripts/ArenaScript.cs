using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    void Awake()
    {
        Session.SetGameState(GameStateEnum.GameStarted);
    }


    void Update()
    {
        
    }
}
