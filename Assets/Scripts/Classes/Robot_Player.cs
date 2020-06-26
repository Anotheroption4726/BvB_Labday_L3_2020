using System;

public class Robot_Player : Robot
{
	//	Constructor
	public Robot_Player(int arg_weaponId, int arg_statAttack, int arg_statHp, int arg_statSpeed, int arg_behaviorProximity, int arg_behaviorAgility, int arg_behaviorAggressivity)
	{
		SetWeaponId(arg_weaponId);
		SetStatAttack(arg_statAttack);
		SetStatHp(arg_statHp);
		SetStatSpeed(arg_statSpeed);
		SetBehaviorProximity(arg_behaviorProximity);
		SetBehaviorAgility(arg_behaviorAgility);
		SetBehaviorAggressivity(arg_behaviorAggressivity);
		SetCurentStatHp(GetStatHp() + 20);
	}
}
