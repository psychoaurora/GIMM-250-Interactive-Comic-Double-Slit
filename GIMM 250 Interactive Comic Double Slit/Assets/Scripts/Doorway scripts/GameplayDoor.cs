using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script and HubWorldDoor script were influenced by Game Code Library on YouTube as well as code by Claude

public class GameplayerDoor : Door
{
    [SerializeField] private string destination;
    [SerializeField] private int doorNumber;

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
        Enter();
    }

    protected override void Enter()
    {
        globalHelper.EnterHubWorld(doorNumber);

        SceneManager.LoadScene(destination);
    }
}
