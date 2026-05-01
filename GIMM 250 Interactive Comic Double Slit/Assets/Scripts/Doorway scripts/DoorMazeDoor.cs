using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMazeDoor : Door
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject playerObj;

    public bool doorIsCorrect = false;
    public SpriteRenderer sprite;
    private VisionCheck checkVision;

    private bool playerIsNearby;
    private bool lastEye = false;
    private float currColor = 0;

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        GameObject playerObj = GameObject.FindWithTag("Player");
        checkVision = playerObj.GetComponent<VisionCheck>();
    }

    void Update()
    {
        if ( lastEye != checkVision.isUsingLeftEye)
        {
            currColor = 1;
            lastEye = checkVision.isUsingLeftEye;
        }
        sprite.color = Color.Lerp(Color.white, doorIsCorrect ? Color.blue : Color.darkRed, currColor);
        sprite.color = !checkVision.isUsingLeftEye ? doorIsCorrect ? Color.blue : Color.darkRed : Color.white;
        if (Input.GetKeyDown(KeyCode.E) && playerIsNearby)
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(playerObj.transform.position);
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
        }
    }

    protected override void Interact()
    {
        Debug.Log("Interacted");
        Enter();
    }

    protected override void Enter()
    {
        playerObj.transform.position = new Vector3(destination.position.x, destination.position.y);
        Debug.Log($"Set player transform to {destination.position.x} and {destination.position.y}");
    }
}
