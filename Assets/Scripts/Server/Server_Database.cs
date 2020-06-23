using System;

public static class Server_Database
{
	//	id
	//	email
	//	password
	//	accountType
	private static Server_User[] usersTable = { new Server_User(1, "testemail@bvb.com", "testpassword", AccountTypeEnum.Player) };

	//	userId
	//	weaponId
	//	statAttack
	//	statHp
	//	statSpeed
	//	behaviorProximity
	//	behaviorAgility
	//	behaviorAggressivity
	private static Server_Robot_Player[] playerRobotsTable = { new Server_Robot_Player(1, 1, 30, 50, 40, 0, 40, 50) };

	//	algoGenId
	//	weaponId
	//	statAttack
	//	statHp
	//	statSpeed
	//	behaviorProximity
	//	behaviorAgility
	//	behaviorAggressivity
	private static Server_Robot_AlgoGen[] algoGenRobotsTable = { new Server_Robot_AlgoGen(1, 2, 10, 70, 20, 0, 20, 10) };

	//	id
	//	bulletId
	//	bulletSpeed
	//	maxRange
	//	minRange
	//	rateOfFire
	//	damageValue
	private static Server_Weapon[] weaponsTable = { new Server_Weapon(1, 1, 4, 8, 4, 4, 2), new Server_Weapon(2, 1, 2, 14, 8, 1, 4) };


	//	Getters
	public static Server_User[] GetUsersTable()
	{
		return usersTable;
	}

	public static Server_Robot_Player[] GetPlayerRobotsTable()
	{
		return playerRobotsTable;
	}

	public static Server_Robot_AlgoGen[] GetAlgoGenRobotsTable()
	{
		return algoGenRobotsTable;
	}

	public static Server_Weapon[] GetWeaponsTable()
	{
		return weaponsTable;
	}


	//	Methodes table User
	public static int GetServer_UserIdFromEmail(string arg_email)
	{
		return 1;
	}

	public static AccountTypeEnum GetServer_UserAccountTypeFromUserId(int arg_userId)
	{
		AccountTypeEnum loc_accountType = AccountTypeEnum.Player;
		return loc_accountType;
	}

	public static String GetServer_UserTokenFromUserId(int arg_userId)
	{
		return "token";
	}

	public static bool CheckServer_UserPasswordFromUserId(int arg_userId, string arg_password)
	{
		return true;
	}

	public static int GetServer_UserWinsFromUserId(int arg_userId)
	{
		return 1;
	}

	public static int GetServer_UserLossesFromUserId(int arg_userId)
	{
		return 1;
	}

	public static void IncrementServer_UserWinsFromUserId(int arg_userId)
	{

	}

	public static void IncrementServer_UserLossesFromUserId(int arg_userId)
	{

	}


	//	Methodes table playerRobots
	public static Server_Robot_Player GetServer_Robot_PlayerFromUserId(int arg_userId)
	{
		return playerRobotsTable[0];
	}

	public static void SetServer_Robot_PlayerFromUserId(int arg_userId, Server_Robot_Player arg_serverRobot)
	{

	}


	//	Methodes table algoGenRobots
	public static Server_Robot_AlgoGen GetServer_Robot_AlgoGenFromId(int arg_id)
	{
		return algoGenRobotsTable[0];
	}


	//	Methodes table weaponsTable
	public static Server_Weapon GetServer_WeaponFromWeaponId(int arg_weaponId)
	{
		return weaponsTable[0];
	}


	// Methodes de conversion robot serveur en robot local
	public static Weapon CreateWeaponFromServer(Server_Weapon arg_serverWeapon)
	{
		Bullet loc_bullet = Session.GetBulletFromBulletId(arg_serverWeapon.GetBulletId());
		return new Weapon(loc_bullet, arg_serverWeapon.GetBulletSpeed(), arg_serverWeapon.GetMaxRange(), arg_serverWeapon.GetMinRange(), arg_serverWeapon.GetRateOfFire(), arg_serverWeapon.GetDamageValue());
	}

	public static Robot_Player CreateRobot_PlayerFromServer(Server_Robot_Player arg_serverRobot)
	{
		Weapon loc_weapon = CreateWeaponFromServer(GetServer_WeaponFromWeaponId(arg_serverRobot.GetWeaponId()));
		return new Robot_Player(loc_weapon, arg_serverRobot.GetStatAttack(), arg_serverRobot.GetStatHp(), arg_serverRobot.GetStatSpeed(), arg_serverRobot.GetBehaviorProximity(), arg_serverRobot.GetbehaviorAgility(), arg_serverRobot.GetBehaviorAggressivity());
	}

	public static Robot_AlgoGen CreateRobot_AlgoGenFromServer(Server_Robot_AlgoGen arg_serverRobot)
	{
		Weapon loc_weapon = CreateWeaponFromServer(GetServer_WeaponFromWeaponId(arg_serverRobot.GetWeaponId()));
		return new Robot_AlgoGen(arg_serverRobot.GetAlgoGenId(), arg_serverRobot.GetWins(), arg_serverRobot.GetLosses(), loc_weapon, arg_serverRobot.GetStatAttack(), arg_serverRobot.GetStatHp(), arg_serverRobot.GetStatSpeed(), arg_serverRobot.GetBehaviorProximity(), arg_serverRobot.GetbehaviorAgility(), arg_serverRobot.GetBehaviorAggressivity());
	}
}