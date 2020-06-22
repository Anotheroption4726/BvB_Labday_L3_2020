using System;

public static class Server_Database
{
	//	id
	//	email
	//	password
	//	accountType
	static Server_User[] usersTable = { new Server_User(1, "testemail@bvb.com", "testpassword", AccountTypeEnum.Player) };

	//	userId
	//	weaponId
	//	statAttack
	//	statHp
	//	statSpeed
	//	behaviorProximity
	//	behaviorAgility
	//	behaviorAggressivity
	static Server_Robot_Player[] playerRobotsTable = { new Server_Robot_Player(1, 1, 30, 50, 40, 0, 40, 50) };

	//	algoGenId
	//	weaponId
	//	statAttack
	//	statHp
	//	statSpeed
	//	behaviorProximity
	//	behaviorAgility
	//	behaviorAggressivity
	static Server_Robot_AlgoGen[] algoGenRobotsTable = { new Server_Robot_AlgoGen(1, 2, 10, 70, 20, 0, 20, 10) };

	//	id
	//	bulletId
	//	bulletSpeed
	//	maxRange
	//	minRange
	//	rateOfFire
	//	damageValue
	static Server_Weapon[] weaponsTable = { new Server_Weapon(1, 1, 4, 8, 4, 4, 2), new Server_Weapon(2, 1, 2, 14, 8, 1, 4) };
}