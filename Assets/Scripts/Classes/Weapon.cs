using System;

public class Weapon
{
	private int id;
	private string name;

	private int bulletId;
	private int bulletSpeed;
	private int maxRange;
	private int minRange;
	private int rateOfFire;
	private int damageValue;
	

	//	Constructor
	public Weapon(int arg_id, string arg_name, int arg_bulletId, int arg_bulletSpeed, int arg_maxRange, int arg_minRange, int arg_rateOfFire, int arg_damageValue)
	{
		id = arg_id;
		name = arg_name;
		bulletId = arg_bulletId;
		bulletSpeed = arg_bulletSpeed;
		maxRange = arg_maxRange;
		minRange = arg_minRange;
		rateOfFire = arg_rateOfFire;
		damageValue = arg_damageValue;
	}


	// Getters
	public int GetId()
	{
		return id;
	}

	public string GetName()
	{
		return name;
	}

	public int GetBulletId()
	{
		return bulletId;
	}

	public int GetBulletSpeed()
	{
		return bulletSpeed;
	}

	public int GetMaxRange()
	{
		return maxRange;
	}

	public int GetMinRange()
	{
		return minRange;
	}

	public int GetRateOfFire()
	{
		return rateOfFire;
	}

	public int GetDamageValue()
	{
		return damageValue;
	}
}
