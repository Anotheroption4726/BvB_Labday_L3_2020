using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    [SerializeField] private RobotScript playerRobot;
    [SerializeField] private RobotScript enemyRobot;

    void Awake()
    {
        if (Session.GetCurentUser() == null)
        {
            playerRobot.SetRobot(
                new Robot_Player(
                    new Weapon(
                        new Bullet(playerRobot.GetTestWeaponBulletId()),
                        playerRobot.GetTestWeaponBulletSpeed(),
                        playerRobot.GetTestWeaponMaxRange(),
                        playerRobot.GetTestWeaponMinRange(),
                        playerRobot.GetTestWeaponRateOfFire(),
                        playerRobot.GetTestWeaponDamageValue()
                    ),
                    playerRobot.GetTestStatAttack(),
                    playerRobot.GetTestStatHp(),
                    playerRobot.GetTestStatSpeed(),
                    playerRobot.GetTestBehaviorProximity(),
                    playerRobot.GetTestBehaviorAgility(),
                    playerRobot.GetTestBehaviorAggressivity()
                )
            );

            enemyRobot.SetRobot(
                new Robot_Player(
                    new Weapon(
                        new Bullet(enemyRobot.GetTestWeaponBulletId()),
                        enemyRobot.GetTestWeaponBulletSpeed(),
                        enemyRobot.GetTestWeaponMaxRange(),
                        enemyRobot.GetTestWeaponMinRange(),
                        enemyRobot.GetTestWeaponRateOfFire(),
                        enemyRobot.GetTestWeaponDamageValue()
                    ),
                    enemyRobot.GetTestStatAttack(),
                    enemyRobot.GetTestStatHp(),
                    enemyRobot.GetTestStatSpeed(),
                    enemyRobot.GetTestBehaviorProximity(),
                    enemyRobot.GetTestBehaviorAgility(),
                    enemyRobot.GetTestBehaviorAggressivity()
                )
            );

            playerRobot.SetRobotState(RobotStateEnum.Ready);
            enemyRobot.SetRobotState(RobotStateEnum.Ready);
        }

        if (playerRobot.GetRobotState().Equals(RobotStateEnum.Ready) && enemyRobot.GetRobotState().Equals(RobotStateEnum.Ready))
        {
            Session.SetGameState(GameStateEnum.GameStarted);
        }
    }


    void Update()
    {
        
    }
}
