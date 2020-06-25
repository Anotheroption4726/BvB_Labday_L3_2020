using UnityEngine;
using UnityEngine.UI;

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

    //  HUD
    [SerializeField] private Image playerRobotHealthDisplay;
    [SerializeField] private Image enemyRobotHealthDisplay;
    [SerializeField] private Text playerRobotNameDisplay;
    [SerializeField] private Text enemyRobotNameDisplay;

    //  Bullets
    [SerializeField] private GameObject[] bulletTable = { };

    private void Awake()
    {
        playerRobotScript = playerRobotGameObject.GetComponent<RobotScript>();
        enemyRobotScript = enemyRobotGameObject.GetComponent<RobotScript>();

        if (muteAudio)
        {
            Game.SetMuteAudio(true);
        }

        if (Game.GetMuteAudio())
        {
            audioManager.enabled = false;
        }
    }


    private void Update()
    {
        // Game start
        if (Game.GetGameState().Equals(GameStateEnum.GamePending))
        {
            if (playerRobotScript.GetRobotState().Equals(RobotStateEnum.Born) || enemyRobotScript.GetRobotState().Equals(RobotStateEnum.Born))
            {
                if (Game.GetCurentUser() == null)
                {
                    SetTestGameRobot(0, playerRobotScript);
                    SetTestGameRobot(1, enemyRobotScript);        
                }
                else
                {
                    if (Game.GetCurentUser().GetAccountType() == AccountTypeEnum.Player)
                    {
                        User_Player loc_player = (User_Player)Game.GetCurentUser();

                        playerRobotScript.SetInGameId(0);
                        playerRobotScript.SetRobot(loc_player.GetUserRobot());
                        playerRobotScript.SetWeapon(Game.GetWeaponFromId(loc_player.GetUserRobot().GetWeaponId()));
                        playerRobotScript.SetBullet(GetBulletFromId(Game.GetWeaponFromId(loc_player.GetUserRobot().GetWeaponId()).GetBulletId()));
                        playerRobotScript.GetBullet().GetComponent<BulletScript_Main>().SetRobotInGameId(0);

                        playerRobotScript.SetInGameId(1);
                        enemyRobotScript.SetRobot(loc_player.GetEnemyRobot());       
                        enemyRobotScript.SetWeapon(Game.GetWeaponFromId(loc_player.GetEnemyRobot().GetWeaponId()));
                        enemyRobotScript.SetBullet(GetBulletFromId(Game.GetWeaponFromId(loc_player.GetEnemyRobot().GetWeaponId()).GetBulletId()));
                        playerRobotScript.GetBullet().GetComponent<BulletScript_Main>().SetRobotInGameId(1);
                    }

                    if (Game.GetCurentUser().GetAccountType() == AccountTypeEnum.Developper)
                    {

                    }
                }

                playerRobotScript.SetHealthDisplay(playerRobotHealthDisplay);
                enemyRobotScript.SetHealthDisplay(enemyRobotHealthDisplay);
                playerRobotScript.SetNameDisplay(playerRobotNameDisplay);
                enemyRobotScript.SetNameDisplay(enemyRobotNameDisplay);

                playerRobotScript.SetRobotState(RobotStateEnum.Ready);
                enemyRobotScript.SetRobotState(RobotStateEnum.Ready);
            }

            if (playerRobotScript.GetRobotState().Equals(RobotStateEnum.Ready) && enemyRobotScript.GetRobotState().Equals(RobotStateEnum.Ready))
            {
                playerRobotScript.SetEnemyRobotGameObject(enemyRobotGameObject);
                enemyRobotScript.SetEnemyRobotGameObject(playerRobotGameObject);
                playerRobotScript.SetEnemyRobotScript(enemyRobotGameObject.GetComponent<RobotScript>());
                enemyRobotScript.SetEnemyRobotScript(playerRobotGameObject.GetComponent<RobotScript>());
                playerRobotScript.SetEnemyRobot(enemyRobotScript.GetComponent<RobotScript>().GetRobot());
                enemyRobotScript.SetEnemyRobot(playerRobotScript.GetComponent<RobotScript>().GetRobot());
                playerRobotScript.SetEnemyWeapon(enemyRobotScript.GetComponent<RobotScript>().GetWeapon());
                enemyRobotScript.SetEnemyWeapon(playerRobotScript.GetComponent<RobotScript>().GetWeapon());
                Game.SetGameState(GameStateEnum.GameStarted);
            }
        }

        //  Game end
        if (Game.GetGameState().Equals(GameStateEnum.GameStarted))
        {
            if (playerRobotScript.GetRobotState() == RobotStateEnum.Dead || enemyRobotScript.GetRobotState() == RobotStateEnum.Dead)
            {
                GameObject[] loc_bulletsToDestroy = GameObject.FindGameObjectsWithTag("BulletTag");

                foreach (GameObject bullet in loc_bulletsToDestroy)
                {
                    Destroy(bullet);
                }

                Game.SetGameState(GameStateEnum.GameFinished);
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
    private void SetTestGameRobot(int arg_inGameId, RobotScript arg_robotScript)
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
        arg_robotScript.GetBullet().GetComponent<BulletScript_Main>().SetRobotInGameId(arg_inGameId);
    }
}
