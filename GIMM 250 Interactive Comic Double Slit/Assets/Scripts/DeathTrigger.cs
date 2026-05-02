using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfo;
    [SerializeField] GameObject[] checkpoints = new GameObject[5];
    [SerializeField] Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerInfo != null)
        {
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (playerInfo.CurrentCheckpoint == checkpoints[i].GetComponent<CheckpointTrigger>().checkpointNumber)
                {
                    playerTransform.position = new Vector3(checkpoints[i].transform.position.x, checkpoints[i].transform.position.y, playerTransform.position.z);
                }
            }
        }
    }
}
