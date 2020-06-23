﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    //  Paramaters
    private Robot robot;
    private RobotStateEnum robotState = RobotStateEnum.Born;
    private RobotAnimStateEnum robotAnimState = RobotAnimStateEnum.Idle;

    //  External
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

    [SerializeField] private int testBulletId;
    [SerializeField] private int testBulletSpeed;
    [SerializeField] private int testMaxRange;
    [SerializeField] private int testMinRange;
    [SerializeField] private int testRateOfFire;
    [SerializeField] private int testDamageValue;


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

    public int GetTestBulletId()
    {
        return testBulletId;
    }

    public int GetTestBulletSpeed()
    {
        return testBulletSpeed;
    }

    public int GetTestMaxRange()
    {
        return testMaxRange;
    }

    public int GetTestMinRange()
    {
        return testMinRange;
    }

    public int GetTestRateOfFire()
    {
        return testMaxRange;
    }

    public int GetTestDamageValue()
    {
        return testMaxRange;
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


    void Awake()
    {
        //  Getting Robot components
        robotRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (Session.GetGameState().Equals(GameStateEnum.GameStarted))
        {

        }
    }
}
