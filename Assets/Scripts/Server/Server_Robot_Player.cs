using System;

public class Server_Robot_Player : Server_Robot
{
    private int userId;
    
    public Server_Robot_Player(int arg_userId, int arg_weaponId, int arg_statAttack, int arg_statHp, int arg_statSpeed, int arg_behaviorProximity, int arg_behaviorAgility, int arg_behaviorAggressivity)
    {
        userId = arg_userId;
        SetWeaponId(arg_weaponId);
        SetStatAttack(arg_statAttack);
        SetStatHp(arg_statHp);
        SetStatSpeed(arg_statSpeed);
        SetBehaviorProximity(arg_behaviorProximity);
        SetBehaviorAgility(arg_behaviorAgility);
        SetBehaviorAggressivity(arg_behaviorAggressivity);
    }

    //  Getters
    public int GetUserId()
    {
        return userId;
    }
}
