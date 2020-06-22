using System;

public static class Session
{
	private static User curentUser;
	private static SessionTypeEnum curentSessionType = SessionTypeEnum.GameTest;
	private static GameStateEnum gameState;
	private static bool muteAudio = false;
	private static float timeScale = 1f;


	// Getters
	public static User GetCurentUser()
	{
		return curentUser;
	}

	public static SessionTypeEnum GetCurentSessionType()
	{
		return curentSessionType;
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
	public static void GetCurentUser(User arg_curentUser)
	{
		curentUser = arg_curentUser;
	}

	public static void GetCurentSessionType(SessionTypeEnum arg_curentSessionType)
	{
		curentSessionType = arg_curentSessionType;
	}

	public static void GetGameState(GameStateEnum arg_gameState)
	{
		gameState = arg_gameState;
	}

	public static void GetMuteAudio(bool arg_muteAudio)
	{
		muteAudio = arg_muteAudio;
	}

	public static void GetTimeScale(float arg_timeScale)
	{
		timeScale = arg_timeScale;
	}


	// Methodes de gestion de combat, d'edition et d'algo genetique
}
