using System;

public class Server_Robot_Player : Server_Robot
{
    int userId;
    
    public Server_Robot_Player(int arg_userId)
    {
        userId = arg_userId;
    }

    //  Getters
    int GetUserId()
    {
        return userId;
    }
}
