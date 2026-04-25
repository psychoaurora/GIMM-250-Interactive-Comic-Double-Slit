using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMazeDoor : Door
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject playerObj;

    private bool playerIsNearby;

    public void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
    }

    void Update()
    {
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
