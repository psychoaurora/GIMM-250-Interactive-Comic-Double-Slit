using UnityEngine;

public class GlobalHelper : MonoBehaviour
{
    public static GlobalHelper instance;

    PlayerInfo playerInfo;
    [SerializeField] GameObject playerInfoObject;

    [SerializeField] GameObject gate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerInfoObject = GameObject.FindGameObjectWithTag("PlayerInfo");
        playerInfo = playerInfoObject.GetComponent<PlayerInfo>();
    }

    public void EnterHubWorld(int doorNumber)
    {
        UpdateCurrentDoor(doorNumber);
    }

    private void UpdateCurrentDoor(int doorNumber)
    {
        if (playerInfo != null)
        {
            if (playerInfo.CurrentDoor == doorNumber)
            {
                playerInfo.CurrentDoor++;
            }
        }
    }

    public void UpdateGate() //Only for the courtyard scene
    {
        gate = GameObject.FindGameObjectWithTag("gate");
        gate.transform.position = new Vector3(transform.position.x, 8.2f, transform.position.z);
    }
}
