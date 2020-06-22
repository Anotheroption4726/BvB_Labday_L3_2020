using System;

public class Robot_AlgoGen : Robot
{
	private int algoGenId;
	private int wins;
	private int losses;
	
	
	//	Constructor
	public Robot_AlgoGen()
	{

	}


	//	Getters
	public int GetAlgoGenId()
	{
		return algoGenId;
	}

	public int GetWins()
	{
		return wins;
	}

	public int GetLosses()
	{
		return losses;
	}


	//	Setters
	public void SetWins(int arg_algoGenRobotWins)
	{
		wins = arg_algoGenRobotWins;
	}

	public void SetLosses(int arg_algoGenRobotLosses)
	{
		losses = arg_algoGenRobotLosses;
	}
}
