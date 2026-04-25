using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assemblies;

//This script was made partly by me looking at the stub game from 110 GroundCheck script and partly
//me taking things from
//https://discussions.unity.com/t/raycast-from-character-to-mouse-position/98333
//this post on the Unity Forums

public class VisionCheck : MonoBehaviour
{
    GameObject player;
    Camera mainCamera;

    [SerializeField] bool isUsingLeftEye = true;

    public GameObject[] movingPlatforms;

    public float lineThickness = .5f;

    private MovingPlatform currPlatform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckVision();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchEye();
        }
    }

    void CheckVision()
    {
        LayerMask layerMask = LayerMask.GetMask("Wall", "Elevator"); //layers the raycast should hit. Can add more because we probably want platforms and not just walls.

        Vector3 screenMousePosition = Input.mousePosition;
        Vector2 worldMousePosition = mainCamera.ScreenToWorldPoint(screenMousePosition);
        Vector2 origin = transform.position;
        Vector2 direction = (worldMousePosition - origin).normalized;
        Vector2 directionRay = (worldMousePosition - origin);
        float distance = Mathf.Infinity;
        Vector2 boxSize = new Vector2(lineThickness, lineThickness);

        //Got the few lines above from Gemini on google.

        RaycastHit2D hit = Physics2D.BoxCast(origin, boxSize, 0f, direction, distance, layerMask);


        if (hit.collider != null)
        {
            Debug.Log("Hitting a wall right now");
            if (currPlatform != null)
                if (currPlatform.gameObject != hit.transform.gameObject)
                    currPlatform.isMoving = !isUsingLeftEye;
            currPlatform = hit.transform.GetComponent<MovingPlatform>();
            currPlatform.isMoving = isUsingLeftEye;
        }
        else if (currPlatform != null)
        {
            Debug.Log("Not hitting a wall");
            currPlatform.isMoving = !isUsingLeftEye;
            currPlatform = null;
        }

        Debug.DrawRay(origin, directionRay, Color.red);
    }

    void SwitchEye()
    {
        isUsingLeftEye = !isUsingLeftEye;

        //Update the sprite, however that will be done

        foreach (GameObject movingPlatform in movingPlatforms)
        {
            movingPlatform.gameObject.GetComponent<MovingPlatform>().isMoving = !movingPlatform.gameObject.GetComponent<MovingPlatform>().isMoving;
        }
    }
}
