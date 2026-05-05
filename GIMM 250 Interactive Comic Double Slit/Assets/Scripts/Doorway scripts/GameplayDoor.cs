using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//This script and HubWorldDoor script were influenced by Game Code Library on YouTube as well as code by Claude

public class GameplayDoor : Door
{
    [SerializeField] private string destination;
    [SerializeField] private int doorNumber;
    [SerializeField] private UnityEvent finalIntro;

    private bool playerIsNearby = false;

    GameObject globalHelperObject;
    GlobalHelper globalHelper;

    PlayerInfo playerInfo;
    [SerializeField] GameObject playerInfoObject;


    private void Awake()
    {
        playerInfoObject = GameObject.FindGameObjectWithTag("PlayerInfo");
        playerInfo = playerInfoObject.GetComponent<PlayerInfo>();

        globalHelperObject = GameObject.FindGameObjectWithTag("GlobalHelper");
        globalHelper = globalHelperObject.GetComponent<GlobalHelper>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsNearby)
        {
            Debug.Log("checking interaction...");
            Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsNearby = true;
            Debug.Log("Player is nearby");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsNearby = false;
            playerInfo = null;
        }
    }

   

    protected override void Interact()
    {
        //if the current object is the player seat, end game instead of doing anything else
        Debug.Log("checking if player seat...");
        if (gameObject.CompareTag("PlayerSeat"))
        {
            GameObject eveSit = GameObject.FindGameObjectWithTag("MainEve");
            eveSit.GetComponent<SpriteRenderer>().enabled = true;
            
            GameObject plr = GameObject.FindGameObjectWithTag("Player");
            plr.transform.position = eveSit.transform.position;
            plr.SetActive(false);
           // GameObject.FindGameObjectWithTag("FinalIntro").SetActive(true);
            finalIntro.Invoke();
        }
        //otherwise, treat it like a door
        else
        {
            Debug.Log("is not player seat. is door.");
            Enter();
        }
        Debug.Log("end of interact");
    }

    protected override void Enter()
    {
        SceneManager.LoadScene(destination);
        globalHelper.EnterHubWorld(doorNumber);
    }
}
