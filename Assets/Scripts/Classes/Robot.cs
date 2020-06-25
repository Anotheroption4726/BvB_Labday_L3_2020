using System;

public abstract class Robot
{
	private int weaponId;
	private int statAttack;				// (0 => 100)
	private int statHp;					// (0 => 100)
	private int statSpeed;				// (0 => 100)
	private int behaviorProximity;		// (0 => 100)
	private int behaviorAgility;		// (0 => 100)
	private int behaviorAggressivity;	// (0 => 100)
	private int curentStatHp;


	//	Getters
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

	public int GetBehaviorAgility()
	{
		return behaviorAgility;
	}

	public int GetBehaviorAggressivity()
	{
		return behaviorAggressivity;
	}

	public int GetCurentStatHp()
	{
		return curentStatHp;
	}


	//	Setters
	public void SetWeaponId(int arg_weaponId)
	{
		weaponId = arg_weaponId;
	}

	public void SetStatAttack(int arg_StatAttack)
	{
		if (arg_StatAttack < 0)
		{
			arg_StatAttack = 0;
		}

		if (arg_StatAttack > 100)
		{
			arg_StatAttack = 100;
		}

		statAttack = arg_StatAttack;
	}

	public void SetStatHp(int arg_StatHp)
	{
		if (arg_StatHp < 0)
		{
			arg_StatHp = 0;
		}

		if (arg_StatHp > 100)
		{
			arg_StatHp = 100;
		}

		statHp = arg_StatHp;
	}

	public void SetStatSpeed(int arg_StatSpeed)
	{
		if (arg_StatSpeed < 0)
		{
			arg_StatSpeed = 0;
		}

		if (arg_StatSpeed > 100)
		{
			arg_StatSpeed = 100;
		}

		statSpeed = arg_StatSpeed;
	}

	public void SetBehaviorProximity(int arg_BehaviorProximity)
	{
		if (arg_BehaviorProximity < 0)
		{
			arg_BehaviorProximity = 0;
		}

		if (arg_BehaviorProximity > 100)
		{
			arg_BehaviorProximity = 100;
		}

		behaviorProximity = arg_BehaviorProximity;
	}

	public void SetBehaviorAgility(int arg_BehaviorAgility)
	{
		if (arg_BehaviorAgility < 0)
		{
			arg_BehaviorAgility = 0;
		}

		if (arg_BehaviorAgility > 100)
		{
			arg_BehaviorAgility = 100;
		}

		behaviorAgility = arg_BehaviorAgility;
	}

	public void SetBehaviorAggressivity(int arg_BehaviorAggressivity)
	{
		if (arg_BehaviorAggressivity < 0)
		{
			arg_BehaviorAggressivity = 0;
		}

		if (arg_BehaviorAggressivity > 100)
		{
			arg_BehaviorAggressivity = 100;
		}

		behaviorAggressivity = arg_BehaviorAggressivity;
	}

	public void SetCurentStatHp(int arg_BehaviorCurentStatHp)
	{
		if (arg_BehaviorCurentStatHp < 0)
		{
			arg_BehaviorCurentStatHp = 0;
		}

		if (arg_BehaviorCurentStatHp > 100)
		{
			arg_BehaviorCurentStatHp = 100;
		}

		curentStatHp = arg_BehaviorCurentStatHp;
	}
}
