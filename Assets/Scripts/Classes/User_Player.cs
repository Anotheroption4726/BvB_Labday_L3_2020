using System;

public class User_Player
{
	private Robot_Player userRobot;
	private Robot_AlgoGen enemyRobot;


	// Constructor
	public User_Player(Robot_Player arg_userRobot, Robot_AlgoGen arg_enemyRobot)
	{
		userRobot = arg_userRobot;
		enemyRobot = arg_enemyRobot;
	}


	// Getters
	public Robot_Player GetUserRobot()
	{
		return userRobot;
	}

	public Robot_AlgoGen GetEnemyRobot()
	{
		return enemyRobot;
	}


	// Setters
	public void SetUserRobot(Robot_Player arg_userRobot)
	{
		userRobot = arg_userRobot;
	}

	public void SetEnemyRobot(Robot_AlgoGen arg_enemyRobot)
	{
		enemyRobot = arg_enemyRobot;
	}
}
