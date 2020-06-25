using System;

public class Server_Robot_AlgoGen : Server_Robot
{
	private int algoGenId;
	private string name;
	private int wins = 0;
	private int losses = 0;

	public Server_Robot_AlgoGen(int arg_algoGenId, string arg_name, int arg_weaponId, int arg_statAttack, int arg_statHp, int arg_statSpeed, int arg_behaviorProximity, int arg_behaviorAgility, int arg_behaviorAggressivity)
	{
		algoGenId = arg_algoGenId;
		name = arg_name;
		SetWeaponId(arg_weaponId);
		SetStatAttack(arg_statAttack);
		SetStatHp(arg_statHp);
		SetStatSpeed(arg_statSpeed);
		SetBehaviorProximity(arg_behaviorProximity);
		SetBehaviorAgility(arg_behaviorAgility);
		SetBehaviorAggressivity(arg_behaviorAggressivity);
	}
	// Getters
	public int GetAlgoGenId()
	{
		return algoGenId;
	}

	public string GetName()
	{
		return name;
	}

	public int GetWins()
	{
		return wins;
	}

	public int GetLosses()
	{
		return losses;
	}

	// Setters
	public void SetWins(int arg_wins)
	{
		wins = arg_wins;
	}

	public void SetLosses(int arg_losses)
	{
		losses = arg_losses;
	}
}
