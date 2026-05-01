using UnityEngine;

public class KnifeCollection : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfo;

    [SerializeField] int knifeNumber;

    int KnifeNumber
    {
        get { return knifeNumber; }
        set { knifeNumber = value; }
    }
    private void Awake()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (knifeNumber > playerInfo.KnifePieces)
        {
            playerInfo.KnifePieces++;
            Debug.Log("destroying this game object");
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
