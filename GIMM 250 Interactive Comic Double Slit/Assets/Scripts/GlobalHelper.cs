using UnityEngine;

public class GlobalHelper : MonoBehaviour
{
    public static GlobalHelper instance;

    PlayerInfo playerInfo;
    [SerializeField] GameObject playerInfoObject;

    GameObject gate;

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

        //gate = GameObject.Find("Gate");
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
        //gate.transform.position = new Vector3(gate.transform.position.x, 8.2f, gate.transform.position.z);
    }
}
