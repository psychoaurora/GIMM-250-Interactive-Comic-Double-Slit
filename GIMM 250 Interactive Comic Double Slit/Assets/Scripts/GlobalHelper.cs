using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHelper : MonoBehaviour
{
    public static GlobalHelper instance;

    [SerializeField] GameObject[] comicObjects = new GameObject[4];

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

    private void Start()
    {
        UpdateCurrentComic();
    }

    public void EnterHubWorld(int doorNumber)
    {
        UpdateCurrentDoor(doorNumber);
        Invoke("UpdateCurrentComic", 2f); //This calls the UpdateCurrentComic method after 2 seconds. 
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

    public void UpdateCurrentComic()
    {
        comicObjects = GameObject.FindGameObjectsWithTag("Comic");

        if (playerInfo.KnifePieces == 3)
        {
            foreach (GameObject comic in comicObjects)
            {
                comic.SetActive(true); //Hopefully should just keep them as true but it works.
            }
        }
        else
        {
            foreach (GameObject comic in comicObjects)
            {
                if (playerInfo.CurrentComic < comic.gameObject.GetComponent<ClickableObject>().comicNumber)
                //if the current comic number is smaller than the comic's number, set it to false.
                {
                    comic.SetActive(false);
                }
            }
        }
    }

    //Call this when you are done with the game. 
    public void ResetPlayerInfo()
    {
        playerInfo.CurrentCheckpoint = 0;
        playerInfo.CurrentComic = 0;
        playerInfo.CurrentDoor = 0;
        playerInfo.KnifePieces = 0;
        playerInfo.KeyFragment = 0;
    }
}
