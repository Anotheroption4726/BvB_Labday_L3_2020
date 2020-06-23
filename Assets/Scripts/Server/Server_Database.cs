using System;
using System.Collections;
using UnityEngine;

public static class Server_Database
{
	//	id
	//	email
	//	password
	//	accountType
	private static Server_User[] usersTable = { new Server_User(1, "testemail@bvb.com", "testpassword", AccountTypeEnum.Player), new Server_User(2, "email@bvb.com", "password", AccountTypeEnum.Developper) };

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


	//	Methodes table User
	public static int GetServer_UserIdFromEmail(string arg_email)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetEmail() == arg_email)
            {
                return lp_user.GetId();
            }
        }
        return 0;
	}

	public static AccountTypeEnum GetServer_UserAccountTypeFromUserId(int arg_userId)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
                return lp_user.GetAccountType();
            }
        }

        return AccountTypeEnum.Player ;
	}

	public static bool CheckServer_UserPasswordFromUserId(int arg_userId, string arg_password)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId && lp_user.GetPassword() == arg_password)
            {
                return true;
            }
                
        }

        return false;
    }

	public static int GetServer_UserWinsFromUserId(int arg_userId)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
                return lp_user.GetWins();
            }

        }

        return 0;
	}

	public static int GetServer_UserLossesFromUserId(int arg_userId)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
                return lp_user.GetLosses();
            }

        }

        return 0;
    }

	public static void IncrementServer_UserWinsFromUserId(int arg_userId)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
                int losses = lp_user.GetLosses();
                lp_user.SetLosses(losses+1);
            }

        }
    }

	public static void IncrementServer_UserLossesFromUserId(int arg_userId)
	{
        foreach (Server_User lp_user in usersTable)
        {
            if (lp_user.GetId() == arg_userId)
            {
                int wins = lp_user.GetWins();
                lp_user.SetWins(wins + 1);
            }

        }
    }


	//	Methodes table playerRobots
	public static Server_Robot_Player GetServer_Robot_PlayerFromUserId(int arg_userId)
	{
		foreach (Server_Robot_Player lp_robotPlayer in playerRobotsTable)
		{
			if (lp_robotPlayer.GetUserId() == arg_userId)
			{
				return lp_robotPlayer;
			}

		}
		return null;
	}

	public static void SetServer_Robot_PlayerFromUserId(int arg_userId, Server_Robot_Player arg_serverRobot)
	{
		for (int i = 0; i < playerRobotsTable.Length; i++)
		{
			if (playerRobotsTable[i].GetUserId() == arg_userId)
			{
				playerRobotsTable[i] = arg_serverRobot;
				break;
			}
		}
	}


	//	Methodes table algoGenRobots
	public static Server_Robot_AlgoGen GetServer_Robot_AlgoGenFromId(int algoGen_id)
	{
		foreach (Server_Robot_AlgoGen lp_robotAlgoGen in algoGenRobotsTable)
		{
			if (lp_robotAlgoGen.GetAlgoGenId() == algoGen_id)
			{
				return lp_robotAlgoGen;
			}
		}
		return null;
	}


	//	Méthodes de conversion d'objets serveur en objets locaux
	public static Robot_Player CreateRobot_PlayerFromServer(Server_Robot_Player arg_serverRobot)
	{
		return new Robot_Player(arg_serverRobot.GetWeaponId(), arg_serverRobot.GetStatAttack(), arg_serverRobot.GetStatHp(), arg_serverRobot.GetStatSpeed(), arg_serverRobot.GetBehaviorProximity(), arg_serverRobot.GetbehaviorAgility(), arg_serverRobot.GetBehaviorAggressivity());
	}

	public static Robot_AlgoGen CreateRobot_AlgoGenFromServer(Server_Robot_AlgoGen arg_serverRobot)
	{
		return new Robot_AlgoGen(arg_serverRobot.GetAlgoGenId(), arg_serverRobot.GetWins(), arg_serverRobot.GetLosses(), arg_serverRobot.GetWeaponId(), arg_serverRobot.GetStatAttack(), arg_serverRobot.GetStatHp(), arg_serverRobot.GetStatSpeed(), arg_serverRobot.GetBehaviorProximity(), arg_serverRobot.GetbehaviorAgility(), arg_serverRobot.GetBehaviorAggressivity());
	}

	public static User_Player CreateUser_PlayerFromServer(Server_User arg_serverUser)
	{
		int loc_randomRobot_AlgoGenId = 1;
		return new User_Player(arg_serverUser.GetId(), arg_serverUser.GetAccountType(), arg_serverUser.GetToken(), CreateRobot_PlayerFromServer(GetServer_Robot_PlayerFromUserId(arg_serverUser.GetId())), CreateRobot_AlgoGenFromServer(GetServer_Robot_AlgoGenFromId(loc_randomRobot_AlgoGenId)));
	}

	public static User_Developper CreateUser_DevelopperFromServer(Server_User arg_serverUser)
	{
		Robot_AlgoGen[] loc_algoGenSessionTable = { };
		return new User_Developper(arg_serverUser.GetId(), arg_serverUser.GetAccountType(), arg_serverUser.GetToken(), loc_algoGenSessionTable);
	}
}