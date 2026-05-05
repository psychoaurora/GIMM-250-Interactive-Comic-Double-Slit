using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script and GamePlayDoor script were influenced by Game Code Library on YouTube as well as code by Claude
public class HubWorldDoor : Door
{
    [SerializeField] string destination;
    [SerializeField] int doorNumber;

    [SerializeField] GameObject selection;

    PlayerInfo playerInfo;
    [SerializeField] GameObject playerInfoObject;

    private bool playerIsNearby = false;

    private void Awake()
    {
        playerInfoObject = GameObject.FindGameObjectWithTag("PlayerInfo");
        playerInfo = playerInfoObject.gameObject.GetComponent<PlayerInfo>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsNearby && playerInfo.CurrentDoor >= doorNumber)
        {
            Interact();
        }

        if (!playerIsNearby)
        {
            selection.SetActive(false);
        }
        else
        {
            selection.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PlayerInfo playerInfo = other.gameObject.GetComponent<PlayerInfo>();

            if (playerInfo != null && doorNumber <= playerInfo.CurrentDoor)
            {
                playerIsNearby = true;
                Debug.Log("Player is nearby");
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsNearby = false;
        }
    }

    protected override void Interact()
    {
        Enter();
    }

    protected override void Enter()
    {
        playerInfo.CurrentCheckpoint = 0;
        SceneManager.LoadScene(destination);
    }
}
