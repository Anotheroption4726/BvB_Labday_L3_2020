using System;

public class User_Developper : User
{
	private Robot_AlgoGen[] robotGenerationTable;


	// Constructor
	public User_Developper(int arg_id, AccountTypeEnum arg_accountType, String arg_name, String arg_token, Robot_AlgoGen[] arg_robotGenerationTable)
	{
		SetId(arg_id);
		SetAccountType(arg_accountType);
		SetName(arg_name);
		SetToken(arg_token);
		robotGenerationTable = arg_robotGenerationTable;
	}


	// Getters
	public Robot_AlgoGen[] GetRobotGenerationTable()
	{
		return robotGenerationTable;
	}


	// Setters
	public void SetRobotGenerationTable(Robot_AlgoGen[] arg_robotGenerationTable)
	{
		robotGenerationTable = arg_robotGenerationTable;
	}
}
