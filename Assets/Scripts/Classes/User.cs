using System;

public abstract class User
{
	private int id;
	private AccountTypeEnum accountType;
	private string name;
	private String token;


	// Getters
	public int GetId()
	{
		return id;
	}

	public AccountTypeEnum GetAccountType()
	{
		return accountType;
	}

	public string GetName()
	{
		return name;
	}

	public String GetToken()
	{
		return token;
	}


	// Setters
	public void SetId(int arg_id)
	{
		id = arg_id;
	}

	public void SetAccountType(AccountTypeEnum arg_accountType)
	{
		accountType = arg_accountType;
	}

	public void SetName(string arg_name)
	{
		name = arg_name;
	}

	public void SetToken(String arg_token)
	{
		token = arg_token;
	}
}
