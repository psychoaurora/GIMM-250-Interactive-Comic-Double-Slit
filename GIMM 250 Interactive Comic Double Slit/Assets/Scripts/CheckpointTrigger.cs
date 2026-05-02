using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public int checkpointNumber;

    [SerializeField] PlayerInfo playerInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInfo.CurrentCheckpoint = checkpointNumber;
        }
    }
}
