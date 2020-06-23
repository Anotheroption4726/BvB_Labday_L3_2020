using System.Collections;
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


    //  Getters
    public Robot GetRobot()
    {
        return robot;
    }

    public RobotStateEnum GetRobotState()
    {
        return robotState;
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
