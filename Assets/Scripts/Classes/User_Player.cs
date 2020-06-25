using System;

public class User_Player : User
{
	private Robot_Player userRobot;
	private Robot_AlgoGen enemyRobot;


	// Constructor
	public User_Player(int arg_id, AccountTypeEnum arg_accountType, String arg_name, String arg_token, Robot_Player arg_userRobot, Robot_AlgoGen arg_enemyRobot)
	{
		SetId(arg_id);
		SetAccountType(arg_accountType);
		SetName(arg_name);
		SetToken(arg_token);
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
