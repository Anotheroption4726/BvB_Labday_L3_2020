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

        if (Session.GetCurentUser() == null)
        {
            playerRobotScript.SetRobot(
                new Robot_Player(
                    new Weapon(
                        new Bullet(playerRobotScript.GetTestWeaponBulletId()),
                        playerRobotScript.GetTestWeaponBulletSpeed(),
                        playerRobotScript.GetTestWeaponMaxRange(),
                        playerRobotScript.GetTestWeaponMinRange(),
                        playerRobotScript.GetTestWeaponRateOfFire(),
                        playerRobotScript.GetTestWeaponDamageValue()
                    ),
                    playerRobotScript.GetTestStatAttack(),
                    playerRobotScript.GetTestStatHp(),
                    playerRobotScript.GetTestStatSpeed(),
                    playerRobotScript.GetTestBehaviorProximity(),
                    playerRobotScript.GetTestBehaviorAgility(),
                    playerRobotScript.GetTestBehaviorAggressivity()
                )
            );

            enemyRobotScript.SetRobot(
                new Robot_Player(
                    new Weapon(
                        new Bullet(enemyRobotScript.GetTestWeaponBulletId()),
                        enemyRobotScript.GetTestWeaponBulletSpeed(),
                        enemyRobotScript.GetTestWeaponMaxRange(),
                        enemyRobotScript.GetTestWeaponMinRange(),
                        enemyRobotScript.GetTestWeaponRateOfFire(),
                        enemyRobotScript.GetTestWeaponDamageValue()
                    ),
                    enemyRobotScript.GetTestStatAttack(),
                    enemyRobotScript.GetTestStatHp(),
                    enemyRobotScript.GetTestStatSpeed(),
                    enemyRobotScript.GetTestBehaviorProximity(),
                    enemyRobotScript.GetTestBehaviorAgility(),
                    enemyRobotScript.GetTestBehaviorAggressivity()
                )
            );

            playerRobotScript.SetRobotState(RobotStateEnum.Ready);
            enemyRobotScript.SetRobotState(RobotStateEnum.Ready);
        }
    }


    private void Update()
    {
        if (Session.GetGameState().Equals(GameStateEnum.GamePending) && playerRobotScript.GetRobotState().Equals(RobotStateEnum.Ready) && enemyRobotScript.GetRobotState().Equals(RobotStateEnum.Ready))
        {
            playerRobotScript.SetEnemyRobotGameObject(enemyRobotGameObject);
            enemyRobotScript.SetEnemyRobotGameObject(playerRobotGameObject);
            Session.SetGameState(GameStateEnum.GameStarted);
        }
    }
}
