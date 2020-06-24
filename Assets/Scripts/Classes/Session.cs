using System;

public static class Session
{
	private static User curentUser;
	private static GameStateEnum gameState = GameStateEnum.GamePending;
	private static bool muteAudio = false;
	private static float timeScale = 1f;
	private static Weapon[] weaponTable = { new Weapon(1, 1, 4, 8, 4, 4, 2), new Weapon(2, 1, 2, 14, 8, 1, 4) };


	// Getters
	public static User GetCurentUser()
	{
		return curentUser;
	}

	public static GameStateEnum GetGameState()
	{
		return gameState;
	}

	public static bool GetMuteAudio()
	{
		return muteAudio;
	}

	public static float GetTimeScale()
	{
		return timeScale;
	}


	// Setters
	public static void SetCurentUser_Player(int arg_userId, AccountTypeEnum arg_accountType, string arg_token, Robot_Player arg_robotPlayer, Robot_AlgoGen arg_robotEnemy)
	{
		curentUser = new User_Player(arg_userId, arg_accountType, arg_token, arg_robotPlayer, arg_robotEnemy);
	}

	public static void SetCurentUser_Developper(int arg_userId, AccountTypeEnum arg_accountType, string arg_token, Robot_AlgoGen[] arg_robotGenerationTable)
	{
		curentUser = new User_Developper(arg_userId, arg_accountType, arg_token, arg_robotGenerationTable);
	}

	public static void SetGameState(GameStateEnum arg_gameState)
	{
		gameState = arg_gameState;
	}

	public static void SetMuteAudio(bool arg_muteAudio)
	{
		muteAudio = arg_muteAudio;
	}

	public static void SetTimeScale(float arg_timeScale)
	{
		timeScale = arg_timeScale;
	}


	// Méthode de récupération d'arme
	static public Weapon GetWeaponFromId(int arg_weaponId)
	{
		foreach (Weapon lp_weapon in weaponTable)
		{
			if (lp_weapon.GetId() == arg_weaponId)
			{
				return lp_weapon;
			}
		}
		return null;
	}
}
