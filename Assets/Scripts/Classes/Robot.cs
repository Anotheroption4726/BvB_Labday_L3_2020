using System;

public abstract class Robot
{
	private Weapon weapon;
	private int statAttack;				// (0 => 100)
	private int statHp;					// (0 => 100)
	private int statSpeed;				// (0 => 100)
	private int behaviorProximity;		// (0 => 100)
	private int behaviorAgility;		// (0 => 100)
	private int behaviorAggressivity;	// (0 => 100)
	private int curentStatHp;


	//	Getters
	public Weapon GetWeapon()
	{
		return weapon;
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
	public void SetWeapon(Weapon arg_Weapon)
	{
		weapon = arg_Weapon;
	}

	public void SetStatAttack(int arg_StatAttack)
	{
		statAttack = arg_StatAttack;
	}

	public void SetStatHp(int arg_StatHp)
	{
		statHp = arg_StatHp;
	}

	public void SetStatSpeed(int arg_StatSpeed)
	{
		statSpeed = arg_StatSpeed;
	}

	public void SetBehaviorProximity(int arg_BehaviorProximity)
	{
		behaviorProximity = arg_BehaviorProximity;
	}

	public void SetBehaviorAgility(int arg_BehaviorAgility)
	{
		behaviorAgility = arg_BehaviorAgility;
	}

	public void SetBehaviorAggressivity(int arg_BehaviorAggressivity)
	{
		behaviorAggressivity = arg_BehaviorAggressivity;
	}

	public void SetCurentStatHp(int arg_BehaviorCurentStatHp)
	{
		curentStatHp = arg_BehaviorCurentStatHp;
	}


	// Setters: ne pas oublier de traiter les exceptions > 100 et < 0 (SURTOUT POUR CURENTSTATHP)
}
