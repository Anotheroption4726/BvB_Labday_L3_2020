using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server_User
{
	private int id;
	private String email;
	private String password;
	private AccountTypeEnum accountType;
	private String token;
	private int wins;
	private int losses;

	//	Constructor
	public Server_User()
	{

	}

	//	Getters
	public int GetId()
	{
		return id;
	}

	public String GetEmail()
	{
		return email;
	}

	public String GetPassword()
	{
		return password;
	}

	public AccountTypeEnum GetAccountType()
	{
		return accountType;
	}

	public String GetToken()
	{
		return token;
	}

	public int GetWins()
	{
		return wins;
	}

	public int GetLosses()
	{
		return losses;
	}

	//	Setters
	public void SetToken(String arg_token)
	{
		token = arg_token;
	}

	public void SetWins(int arg_wins)
	{
		wins = arg_wins;
	}

	public void SetLosses(int arg_losses)
	{
		losses = arg_losses;
	}
}
