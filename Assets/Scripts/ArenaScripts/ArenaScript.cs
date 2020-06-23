using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    [SerializeField] private GameObject playerRobotGameObject;
    [SerializeField] private GameObject enemyRobotGameObject;
    private RobotScript playerRobotScript;
    private RobotScript enemyRobotScript;

    private void Awake()
    {
        playerRobotScript = playerRobotGameObject.GetComponent<RobotScript>();
        enemyRobotScript = enemyRobotGameObject.GetComponent<RobotScript>();
    }


    private void Update()
    {
        if (Session.GetGameState().Equals(GameStateEnum.GamePending))
        {
            if (playerRobotScript.GetRobotState().Equals(RobotStateEnum.Born) || enemyRobotScript.GetRobotState().Equals(RobotStateEnum.Born))
            {
                if (Session.GetCurentUser() == null)
                {
                    SetTestRobot(playerRobotScript);
                    SetTestRobot(enemyRobotScript);

                    playerRobotScript.SetRobotState(RobotStateEnum.Ready);
                    enemyRobotScript.SetRobotState(RobotStateEnum.Ready);
                }
            }

            if (playerRobotScript.GetRobotState().Equals(RobotStateEnum.Ready) && enemyRobotScript.GetRobotState().Equals(RobotStateEnum.Ready))
            {
                playerRobotScript.SetEnemyRobotGameObject(enemyRobotGameObject);
                enemyRobotScript.SetEnemyRobotGameObject(playerRobotGameObject);
                Session.SetGameState(GameStateEnum.GameStarted);
            }
        }
    }


    //  Methode d'assignement de robot test
    private void SetTestRobot(RobotScript arg_robotScript)
    {
        arg_robotScript.SetRobot(
            new Robot_Player(
                new Weapon(
                    new Bullet(arg_robotScript.GetTestWeaponBulletId()),
                    arg_robotScript.GetTestWeaponBulletSpeed(),
                    arg_robotScript.GetTestWeaponMaxRange(),
                    arg_robotScript.GetTestWeaponMinRange(),
                    arg_robotScript.GetTestWeaponRateOfFire(),
                    arg_robotScript.GetTestWeaponDamageValue()
                ),
                arg_robotScript.GetTestStatAttack(),
                arg_robotScript.GetTestStatHp(),
                arg_robotScript.GetTestStatSpeed(),
                arg_robotScript.GetTestBehaviorProximity(),
                arg_robotScript.GetTestBehaviorAgility(),
                arg_robotScript.GetTestBehaviorAggressivity()
            )
        );
    }
}
