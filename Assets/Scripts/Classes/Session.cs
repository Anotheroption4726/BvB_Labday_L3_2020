using System;

public static class Session
{
	private static User curentUser;
	private static Bullet[] bulletTable = { new Bullet(1) };
	private static GameStateEnum gameState;
	private static bool muteAudio = false;
	private static float timeScale = 1f;


	// Getters
	public static User GetCurentUser()
	{
		return curentUser;
	}

	public static Bullet GetBulletFromBulletId(int arg_bulletId)
	{
		return bulletTable[0];
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
}
