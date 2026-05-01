using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfo;
    [SerializeField] int checkPointNumber;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If the player's current checkpoint is equal to the checkpoint
    //number of this object, then check if player checkpoint is greater
    //than or equal to this object's checkPointNumber
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided with it");
            if (playerInfo != null)
            {
                if (playerInfo.CurrentCheckpoint >= checkPointNumber)
                {
                    Debug.Log("wrong operator probably");
                    return;
                }
                else
                {
                    playerInfo.CurrentCheckpoint = checkPointNumber;
                    Debug.Log("Updated the current checkpoint");
                }
            }
            else
            {
                Debug.LogWarning("playerInfo is missing!");
            }
        }
    }
}
