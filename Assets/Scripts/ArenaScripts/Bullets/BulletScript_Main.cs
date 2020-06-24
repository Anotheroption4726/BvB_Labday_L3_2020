using UnityEngine;

public class BulletScript_Main : MonoBehaviour
{
    [SerializeField] private int id;
    private int robotInGameId;

    public int GetId()
    {
        return id;
    }

    public int GetRobotInGameId()
    {
        return robotInGameId;
    }

    public void SetRobotInGameId(int arg_robotInGameId)
    {
        robotInGameId = arg_robotInGameId;
    }

    void OnCollisionEnter(Collision objectCollided)
    {
        if (objectCollided.gameObject.tag == "RobotTag")
        {
            RobotScript robotCollided;
            robotCollided = objectCollided.gameObject.GetComponent<RobotScript>();

            if (robotCollided.GetInGameId() != id)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
