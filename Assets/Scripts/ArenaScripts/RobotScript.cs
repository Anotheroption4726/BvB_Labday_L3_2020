using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    //  Paramaters
    private Robot robot;
    private RobotStateEnum robotState = RobotStateEnum.Born;
    private RobotAnimStateEnum robotAnimState = RobotAnimStateEnum.Idle;
    [SerializeField] private GameObject enemyRobotGameObject;

    //  Components
    private Rigidbody robotRigidbody;

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
    public Robot GetRobot()
    {
        return robot;
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
    public void SetRobot(Robot arg_robot)
    {
        robot = arg_robot;
    }

    public void SetRobotState(RobotStateEnum arg_robotState)
    {
        robotState = arg_robotState;
    }

    public void SetEnemyRobotGameObject(GameObject arg_enemyRobot)
    {
        enemyRobotGameObject = arg_enemyRobot;
    }


    private void Awake()
    {
        //  Getting Robot components
        robotRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        if (Session.GetGameState().Equals(GameStateEnum.GameStarted))
        {
            RobotAim(transform, enemyRobotGameObject.transform.position);

            if (RobotCheckAngle(transform, enemyRobotGameObject.transform.position))
            {
                if (RobotCheckRange(transform, enemyRobotGameObject.transform.position) >= robot.GetWeapon().GetMaxRange())
                {
                    //RobotMove(1, robotRigidbody);
                    //RobotDodge(transform, robotRigidbody);
                }
                else if (RobotCheckRange(transform, enemyRobotGameObject.transform.position) <= robot.GetWeapon().GetMinRange())
                {
                    //RobotMove(-1, robotRigidbody);
                    //RobotDodge(transform, robotRigidbody);
                }
                else
                {
                    //RobotEventShoot();
                }
            }
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
}
