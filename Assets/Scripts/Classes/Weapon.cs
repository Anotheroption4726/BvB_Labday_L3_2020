using System;

public class Weapon
{
	private Bullet bullet;
	private int bulletSpeed;
	private int maxRange;
	private int minRange;
	private int rateOfFire;
	private int damageValue;
	

	//	Constructor
	public Weapon(Bullet arg_bullet, int arg_bulletSpeed, int arg_maxRange, int arg_minRange, int arg_rateOfFire, int arg_damageValue)
	{
		bullet = arg_bullet;
		bulletSpeed = arg_bulletSpeed;
		maxRange = arg_maxRange;
		minRange = arg_minRange;
		rateOfFire = arg_rateOfFire;
		damageValue = arg_damageValue;
	}


	// Getters
	public Bullet GetBulletId()
	{
		return bullet;
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
