using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] Transform destination;
    GameObject player;
    Transform playerTransform;

    PlayerInfo playerInfo;

    [SerializeField] GameObject[] checkPoints = new GameObject[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;

        playerInfo = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();

        //checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null)
        {
            for (int i = 0; i < checkPoints.Length; i++)
            {
                if (playerInfo.CurrentCheckpoint == i)
                {
                    playerTransform.position = new Vector3(checkPoints[i].transform.position.x, checkPoints[i].transform.position.y, player.transform.position.z);
                    Debug.Log("Moved the player");
                }
            }
        }
        else
        {
            Debug.LogWarning("playerInfo is null!");
        }
    }
}
