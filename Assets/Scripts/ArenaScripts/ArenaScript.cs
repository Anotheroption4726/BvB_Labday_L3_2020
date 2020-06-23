using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    [SerializeField] private GameObject playerRobotGameObject;
    [SerializeField] private GameObject enemyRobotGameObject;
    private RobotScript playerRobotScript;
    private RobotScript enemyRobotScript;
    [SerializeField] private static GameObject[] bulletTable = { };
    private static Weapon[] weaponTable = { new Weapon(1, 1, 4, 8, 4, 4, 2), new Weapon(2, 1, 2, 14, 8, 1, 4) };

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

    /*
    public static GameObject GetBulletFromId(int arg_bulletId)
    {
        foreach (GameObject lp_bullet in bulletTable)
        {
            if (lp_bullet.GetId() == arg_bulletId)
            {
                return lp_bullet;
            }
        }
        return null;
    }
    */

    public static Weapon GetWeaponFromId(int arg_weaponId)
    {
        foreach (Weapon lp_weapon in weaponTable)
        {
            if (lp_weapon.GetId() == arg_weaponId)
            {
                return lp_weapon;
            }
        }
        return null;
    }


    //  Methode d'assignement de robot test
    private void SetTestRobot(RobotScript arg_robotScript)
    {
        arg_robotScript.SetRobot(
            new Robot_Player(
                0,
                arg_robotScript.GetTestStatAttack(),
                arg_robotScript.GetTestStatHp(),
                arg_robotScript.GetTestStatSpeed(),
                arg_robotScript.GetTestBehaviorProximity(),
                arg_robotScript.GetTestBehaviorAgility(),
                arg_robotScript.GetTestBehaviorAggressivity()
            )
        );

        arg_robotScript.SetWeapon(
            new Weapon(
                0,
                arg_robotScript.GetTestWeaponBulletId(),
                arg_robotScript.GetTestWeaponBulletSpeed(),
                arg_robotScript.GetTestWeaponMaxRange(),
                arg_robotScript.GetTestWeaponMinRange(),
                arg_robotScript.GetTestWeaponRateOfFire(),
                arg_robotScript.GetTestWeaponDamageValue()
            )
        );
    }
}
