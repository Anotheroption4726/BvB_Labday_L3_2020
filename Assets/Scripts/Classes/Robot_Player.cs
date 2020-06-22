using System;

public class Robot_Player : Robot
{
	//	Constructor
	public Robot_Player(Weapon arg_weapon, int arg_statAttack, int arg_statHp, int arg_statSpeed, int arg_behaviorProximity, int arg_behaviorAgility, int arg_behaviorAggressivity)
	{
		SetWeapon(arg_weapon);
		SetStatAttack(arg_statAttack);
		SetStatHp(arg_statHp);
		SetStatSpeed(arg_statSpeed);
		SetBehaviorProximity(arg_behaviorProximity);
		SetBehaviorAgility(arg_behaviorAgility);
		SetBehaviorAggressivity(arg_behaviorAggressivity);
		SetCurentStatHp(GetStatHp());
	}
}
