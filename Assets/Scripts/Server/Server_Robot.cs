using System;

public abstract class Server_Robot
{
	private int weaponId;
	private int statAttack;				// (0 => 100)
	private int statHp;					// (0 => 100)
	private int statSpeed;				// (0 => 100)
	private int behaviorProximity;		// (0 => 100)
	private int behaviorAgility;		// (0 => 100)
	private int behaviorAggressivity;   // (0 => 100)


	// Getters
	public int GetWeaponId()
	{
		return weaponId;
	}

	public int GetStatAttack()
	{
		return statAttack;
	}

	public int GetStatHp()
	{
		return statHp;
	}

	public int GetStatSpeed()
	{
		return statSpeed;
	}

	public int GetBehaviorProximity()
	{
		return behaviorProximity;
	}

	public int GetbehaviorAgility()
	{
		return behaviorAgility;
	}

	public int GetBehaviorAggressivity()
	{
		return behaviorAggressivity;
	}


	// Setters
	public void SetWeaponId(int arg_weaponId)
	{
		weaponId = arg_weaponId;
	}

	public void SetStatAttack(int arg_statAttack)
	{
		statAttack = arg_statAttack;
	}

	public void SetStatHp(int arg_statHp)
	{
		statHp = arg_statHp;
	}

	public void SetStatSpeed(int arg_statSpeed)
	{
		statSpeed = arg_statSpeed;
	}

	public void SetBehaviorProximity(int arg_behaviorProximity)
	{
		behaviorProximity = arg_behaviorProximity;
	}

	public void SetBehaviorAgility(int arg_behaviorAgility)
	{
		behaviorAgility = arg_behaviorAgility;
	}

	public void SetBehaviorAggressivity(int arg_behaviorAggressivity)
	{
		behaviorAggressivity = arg_behaviorAggressivity;
	}
}
