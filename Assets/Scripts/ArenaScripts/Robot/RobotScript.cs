using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    //  Paramaters
    private int inGameId;
    private Robot robot;
    private Weapon weapon;
    private GameObject bullet;
    private RobotStateEnum robotState = RobotStateEnum.Born;
    private RobotAnimStateEnum robotAnimState = RobotAnimStateEnum.Idle;

    //  Enemy Robot
    private GameObject enemyRobotGameObject;
    private Robot enemyRobot;
    private Weapon enemyWeapon;

    private float nextFire;
    private bool readyToShoot;

    //  Components
    private Rigidbody robotRigidbody;
    private RobotActionsScript animationController;

    //  Test Parameters
    [SerializeField] private int testStatAttack;
    [SerializeField] private int testStatHp;
    [SerializeField] private int testStatSpeed;

    [SerializeField] private int testBehaviorProximity;
    [SerializeField] private int testBehaviorAgility;
    [SerializeField] private int testBehaviorAggressivity;

    [SerializeField] private int testWeaponBulletId;
    [SerializeField] private int testWeaponBulletSpeed;
    [SerializeField] private int testWeaponMaxRange;
    [SerializeField] private int testWeaponMinRange;
    [SerializeField] private int testWeaponRateOfFire;
    [SerializeField] private int testWeaponDamageValue;


    //  Getters
    public int GetInGameId()
    {
        return inGameId;
    }

    public Robot GetRobot()
    {
        return robot;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public GameObject GetBullet()
    {
        return bullet;
    }

    public RobotStateEnum GetRobotState()
    {
        return robotState;
    }

    public int GetTestStatAttack()
    {
        return testStatAttack;
    }

    public int GetTestStatHp()
    {
        return testStatHp;
    }

    public int GetTestStatSpeed()
    {
        return testStatSpeed;
    }

    public int GetTestBehaviorProximity()
    {
        return testBehaviorProximity;
    }

    public int GetTestBehaviorAgility()
    {
        return testBehaviorAgility;
    }

    public int GetTestBehaviorAggressivity()
    {
        return testBehaviorAggressivity;
    }

    public int GetTestWeaponBulletId()
    {
        return testWeaponBulletId;
    }

    public int GetTestWeaponBulletSpeed()
    {
        return testWeaponBulletSpeed;
    }

    public int GetTestWeaponMaxRange()
    {
        return testWeaponMaxRange;
    }

    public int GetTestWeaponMinRange()
    {
        return testWeaponMinRange;
    }

    public int GetTestWeaponRateOfFire()
    {
        return testWeaponMaxRange;
    }

    public int GetTestWeaponDamageValue()
    {
        return testWeaponMaxRange;
    }


    //  Setters
    public void SetInGameId(int arg_inGameId)
    {
        inGameId = arg_inGameId;
    }

    public void SetRobot(Robot arg_robot)
    {
        robot = arg_robot;
    }

    public void SetWeapon(Weapon arg_weapon)
    {
        weapon = arg_weapon;
    }

    public void SetBullet(GameObject arg_bullet)
    {
        bullet = arg_bullet;
    }

    public void SetRobotState(RobotStateEnum arg_robotState)
    {
        robotState = arg_robotState;
    }

    public void SetEnemyRobotGameObject(GameObject arg_enemyRobotGameObject)
    {
        enemyRobotGameObject = arg_enemyRobotGameObject;
    }

    public void SetEnemyRobot(Robot arg_enemyRobot)
    {
        enemyRobot = arg_enemyRobot;
    }

    public void SetEnemyWeapon(Weapon arg_enemyWeapon)
    {
        enemyWeapon = arg_enemyWeapon;
    }


    //  Methodes in-game
    private void Awake()
    {
        robotRigidbody = gameObject.GetComponent<Rigidbody>();
        animationController = GetRobotAnimationController();
    }

    private void FixedUpdate()
    {
        if (Game.GetGameState().Equals(GameStateEnum.GameStarted))
        {
            if (robotRigidbody.velocity.magnitude > 10)
            {
                NormalizeRigidBodyVelocity(robotRigidbody);
            }

            RobotAim(transform, enemyRobotGameObject.transform.position);

            if (RobotCheckAngle(transform, enemyRobotGameObject.transform.position))
            {
                if (RobotCheckRange(transform, enemyRobotGameObject.transform.position) >= weapon.GetMaxRange())
                {
                    RobotMove(1, robotRigidbody);
                    RobotDodge(transform, robotRigidbody);
                }
                else if (RobotCheckRange(transform, enemyRobotGameObject.transform.position) <= weapon.GetMinRange())
                {
                    RobotMove(-1, robotRigidbody);
                    RobotDodge(transform, robotRigidbody);
                }
                else
                {
                    RobotShoot();
                }
            }
        }
    }

    void OnCollisionEnter(Collision arg_collision)
    {
        if (Game.GetGameState().Equals(GameStateEnum.GameStarted))
        {
            if (arg_collision.gameObject.tag == "BulletTag")
            {
                BulletScript_Main loc_bulletCollided;
                loc_bulletCollided = arg_collision.gameObject.GetComponent<BulletScript_Main>();

                if (loc_bulletCollided.GetRobotInGameId() != inGameId)
                {
                    animationController.Hit1();
                    robot.SetCurentStatHp(robot.GetCurentStatHp() - enemyRobot.GetStatAttack() / 10 * enemyWeapon.GetDamageValue());
                    Debug.Log(robot.GetCurentStatHp());
                    //HUDController.updateHealthBar(healthDisplay, robot.curentStatHp, robot.statHp);
                }
            }
        }
    }


    //  Récupération du scricpt gérant les animations
    private RobotActionsScript GetRobotAnimationController()
    {
        RobotActionsScript loc_animationController = new RobotActionsScript();
        Component[] loc_retrievedScripts;

        loc_retrievedScripts = GetComponentsInChildren<RobotActionsScript>();

        foreach (RobotActionsScript lp_animScript in loc_retrievedScripts)
        {
            loc_animationController = lp_animScript;
        }

        return loc_animationController;
    }


    // Fonction de management des Animations
    private void AnimationStateChecker(RobotAnimStateEnum arg_robotStateAnimAfter)
    {
        if (robotAnimState != arg_robotStateAnimAfter)
        {
            if (arg_robotStateAnimAfter == RobotAnimStateEnum.Idle)
            {
                animationController.Idle1();
            }

            if (arg_robotStateAnimAfter == RobotAnimStateEnum.DodgeRight)
            {
                animationController.StrafeRight();
            }

            if (arg_robotStateAnimAfter == RobotAnimStateEnum.DodgeLeft)
            {
                animationController.StrafeLeft();
            }

            if (arg_robotStateAnimAfter == RobotAnimStateEnum.Dead)
            {
                animationController.Dead3();
            }

            robotAnimState = arg_robotStateAnimAfter;
        }
    }


    //  Normalisation de la Vitesse du RigidBody
    private void NormalizeRigidBodyVelocity(Rigidbody arg_robotRigidbody)
    {
        float magnitudeDecrease = 1.5f;

        if (arg_robotRigidbody.velocity.x > 0)
        {
            arg_robotRigidbody.velocity = new Vector3(arg_robotRigidbody.velocity.x - magnitudeDecrease, 0, arg_robotRigidbody.velocity.z);
        }

        if (arg_robotRigidbody.velocity.x < 0)
        {
            arg_robotRigidbody.velocity = new Vector3(arg_robotRigidbody.velocity.x + magnitudeDecrease, 0, arg_robotRigidbody.velocity.z);
        }

        if (arg_robotRigidbody.velocity.z > 0)
        {
            arg_robotRigidbody.velocity = new Vector3(arg_robotRigidbody.velocity.x, 0, arg_robotRigidbody.velocity.z - magnitudeDecrease);
        }

        if (arg_robotRigidbody.velocity.z < 0)
        {
            arg_robotRigidbody.velocity = new Vector3(arg_robotRigidbody.velocity.x, 0, arg_robotRigidbody.velocity.z + magnitudeDecrease);
        }
    }


    //  Méthode de rotation/visée
    private void RobotAim(Transform arg_robotTransform, Vector3 arg_enemyTransformPosition)
    {
        Vector3 loc_vectorDirection = arg_enemyTransformPosition - arg_robotTransform.position;
        float loc_robotRotationStep = Convert.ToSingle(robot.GetStatSpeed());
        loc_robotRotationStep = (loc_robotRotationStep / 15) * Time.deltaTime;

        Vector3 loc_newDirection = Vector3.RotateTowards(arg_robotTransform.forward, loc_vectorDirection, loc_robotRotationStep, 0.0f);
        arg_robotTransform.rotation = Quaternion.LookRotation(loc_newDirection);
    }


    //  Méthode d'evaluation de l'angle
    private bool RobotCheckAngle(Transform arg_robotTransform, Vector3 arg_enemyTransformPosition)
    {
        Vector3 loc_targetDirection = arg_enemyTransformPosition - arg_robotTransform.position;
        float loc_angleValue = Vector3.Angle(loc_targetDirection, arg_robotTransform.forward);

        if (loc_angleValue < 45f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //  Méthode d'evaluation de la distance
    private float RobotCheckRange(Transform arg_robotTransform, Vector3 arg_enemyTransformPosition)
    {
        float loc_distance = Vector3.Distance(arg_enemyTransformPosition, arg_robotTransform.position);
        return loc_distance;
    }


    //  Méthode de déplacement
    private void RobotMove(int arg_direction, Rigidbody arg_robotRigidbody)
    {
        double loc_robotSpeedDouble = Convert.ToSingle(arg_direction * robot.GetStatSpeed() / 2);
        loc_robotSpeedDouble = Math.Round(loc_robotSpeedDouble, 2);
        float loc_robotSpeedFloat = (float)loc_robotSpeedDouble;

        if (robot.GetStatSpeed() >= 0)
        {
            arg_robotRigidbody.AddForce(arg_robotRigidbody.transform.TransformDirection(new Vector3(0.0f, 0.0f, loc_robotSpeedFloat)));
        }
        else
        {
            arg_robotRigidbody.AddForce(arg_robotRigidbody.transform.TransformDirection(new Vector3(0.0f, 0.0f, 0.75f * loc_robotSpeedFloat)));
        }
    }


    //  Méthode d'Esquive
    private void RobotDodge(Transform arg_robotTransform, Rigidbody arg_robotRigidbody)
    {
        int loc_randomNumber = UnityEngine.Random.Range(0, 100);
        float loc_timer = 0.0f;
        float loc_runTime = 0.1f;
        int loc_dodgeDirectionRight = 0;
        float loc_dodgeFrequency = Convert.ToSingle(robot.GetBehaviorAgility()) / 10;
        float loc_dodgeSpeed = Convert.ToSingle(robot.GetStatSpeed()) * 8;

        RaycastHit loc_raycastHit;

        //Debug.DrawRay(transform.position, transform.right * 3, Color.red);
        //Debug.DrawRay(transform.position, -transform.right * 3, Color.red);

        if ((loc_randomNumber % 2) == 0)
        {
            if (!Physics.Raycast(arg_robotTransform.position, arg_robotTransform.right, out loc_raycastHit, 3))
            {
                loc_dodgeDirectionRight = 1;
            }
            else
            {
                loc_dodgeDirectionRight = -1;
            }

        }
        else if ((loc_randomNumber % 2) != 0)
        {
            if (!Physics.Raycast(arg_robotTransform.position, -arg_robotTransform.right, out loc_raycastHit, 3))
            {
                loc_dodgeDirectionRight = -1;
            }
            else
            {
                loc_dodgeDirectionRight = 1;
            }
        }

        if (loc_randomNumber + (loc_dodgeFrequency) > 100)
        {
            while (loc_timer < loc_runTime)
            {
                arg_robotRigidbody.AddForce(arg_robotRigidbody.transform.TransformDirection(new Vector3(loc_dodgeDirectionRight * loc_dodgeSpeed, 0.0f, 0.0f)));
                loc_timer += Time.deltaTime;
            }

            arg_robotRigidbody.velocity = new Vector3(0, 0, arg_robotRigidbody.velocity.z);
        }
    }


    //  Events d'attaque/tir
    private void RobotShoot()
    {
        if (readyToShoot)
        {
            animationController.Fire();
            readyToShoot = false;
        }
        else
        {
            AnimationStateChecker(RobotAnimStateEnum.Idle);
            readyToShoot = RobotReload();
        }
    }

    private bool RobotReload()
    {
        nextFire -= Time.deltaTime;
        float loc_attackAggressivity = 1 + (Convert.ToSingle(robot.GetBehaviorAggressivity()) / 75);

        if (nextFire <= 0)
        {
            nextFire = 1 / (weapon.GetRateOfFire() * loc_attackAggressivity);
            return true;
        }
        else
        {
            return false;
        }
    }
}
