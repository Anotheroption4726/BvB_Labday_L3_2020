using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    //  Sound
    [SerializeField] private AudioListener audioManager;
    [SerializeField] private bool muteAudio = true;

    //  Robots
    [SerializeField] private GameObject playerRobotGameObject;
    [SerializeField] private GameObject enemyRobotGameObject;
    private RobotScript playerRobotScript;
    private RobotScript enemyRobotScript;

    //  Bullets
    [SerializeField] private GameObject[] bulletTable = { };

    private void Awake()
    {
        playerRobotScript = playerRobotGameObject.GetComponent<RobotScript>();
        enemyRobotScript = enemyRobotGameObject.GetComponent<RobotScript>();

        if (muteAudio)
        {
            audioManager.enabled = false;
        }
    }


    private void Update()
    {
        if (Game.GetGameState().Equals(GameStateEnum.GamePending))
        {
            if (playerRobotScript.GetRobotState().Equals(RobotStateEnum.Born) || enemyRobotScript.GetRobotState().Equals(RobotStateEnum.Born))
            {
                if (Game.GetCurentUser() == null)
                {
                    SetTestRobot(0, playerRobotScript);
                    SetTestRobot(1, enemyRobotScript);

                    playerRobotScript.SetRobotState(RobotStateEnum.Ready);
                    enemyRobotScript.SetRobotState(RobotStateEnum.Ready);
                }
            }

            if (playerRobotScript.GetRobotState().Equals(RobotStateEnum.Ready) && enemyRobotScript.GetRobotState().Equals(RobotStateEnum.Ready))
            {
                playerRobotScript.SetEnemyRobotGameObject(enemyRobotGameObject);
                enemyRobotScript.SetEnemyRobotGameObject(playerRobotGameObject);
                Game.SetGameState(GameStateEnum.GameStarted);
            }
        }
    }


    private GameObject GetBulletFromId(int arg_bulletId)
    {
        foreach (GameObject lp_bullet in bulletTable)
        {
            BulletScript_Main loc_bulletScriptMain = lp_bullet.GetComponent<BulletScript_Main>();

            if (loc_bulletScriptMain.GetId() == arg_bulletId)
            {
                return lp_bullet;
            }
        }
        return null;
    }


    //  Methode d'assignement de robot test
    private void SetTestRobot(int arg_inGameId, RobotScript arg_robotScript)
    {
        arg_robotScript.SetInGameId(arg_inGameId);

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
                "Weapon Test",
                arg_robotScript.GetTestWeaponBulletId(),
                arg_robotScript.GetTestWeaponBulletSpeed(),
                arg_robotScript.GetTestWeaponMaxRange(),
                arg_robotScript.GetTestWeaponMinRange(),
                arg_robotScript.GetTestWeaponRateOfFire(),
                arg_robotScript.GetTestWeaponDamageValue()
            )
        );

        arg_robotScript.SetBullet(GetBulletFromId(arg_robotScript.GetWeapon().GetBulletId()));
        arg_robotScript.GetBullet().GetComponent<BulletScript_Main>().SetRobotInGameId(arg_robotScript.GetInGameId());
    }
}
