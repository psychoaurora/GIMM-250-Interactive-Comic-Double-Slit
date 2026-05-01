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

    public bool isUsingLeftEye = true;

    [SerializeField] SpriteRenderer eyeSprite;
    [SerializeField] SpriteRenderer beam;
    [SerializeField] ParticleSystem particles;

    [SerializeField] Transform mainPoint;
    [SerializeField] Transform line;
    [SerializeField] Transform point;

    [SerializeField] Color eyeCR;
    [SerializeField] Color eyeCL;

    [SerializeField] MovingPlatformViewers viewers;

    public GameObject[] movingPlatforms;

    public float lineThickness = .5f;
    public bool eyeActive = false;

    private MovingPlatform currPlatform;
    private Animator animator;

    Vector3 defaultPos;
    Quaternion defaultRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();

        defaultPos = point.localPosition;
        defaultRot = point.localRotation;


    }

    // Update is called once per frame
    void Update()
    {
        CheckVision();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchEye();
        }
        beam.enabled = eyeActive;

        if (eyeActive && particles.isStopped)
        {
            particles.Play();
        }
        else if (!eyeActive)
        {
            particles.Stop();
        }
    }

    float GetAngle(Vector2 a, Vector2 b)
    {
        float atan = Mathf.Atan2(b.y - a.y, b.x - a.x);
        return atan * (180 / Mathf.PI);
    }

    void CheckVision()
    {
        LayerMask layerMask = LayerMask.GetMask("Wall", "Elevator", "Platform"); //layers the raycast should hit. Can add more because we probably want platforms and not just walls.

        Vector3 screenMousePosition = Input.mousePosition;
        Vector2 worldMousePosition = mainCamera.ScreenToWorldPoint(screenMousePosition);
        Vector2 origin = transform.position;
        Vector2 direction = (worldMousePosition - origin).normalized;
        Vector2 directionRay = (worldMousePosition - origin);
        float distance = Mathf.Infinity;
        Vector2 boxSize = new Vector2(lineThickness, lineThickness);

        //Got the few lines above from Gemini on google.

        RaycastHit2D hit = Physics2D.BoxCast(origin, boxSize, 0f, direction, Mathf.Abs(distance), layerMask);


        if (hit.collider != null)
        {
            Debug.Log("Hitting a wall right now");
            if (currPlatform != null)
                if (currPlatform.gameObject != hit.transform.gameObject)
                {
                    currPlatform.isMoving = !isUsingLeftEye;
                    if (viewers != null)
                        viewers.RemoveViewer(currPlatform.gameObject);
                }
            currPlatform = hit.transform.GetComponent<MovingPlatform>();
            currPlatform.isMoving = isUsingLeftEye;
            //Debug.Log(currPlatform.gameObject);
            if (viewers != null)
                viewers.AddViewer(currPlatform.gameObject);
        }
        else if (currPlatform != null)
        {
            Debug.Log("Not hitting a wall");
            //Debug.Log(currPlatform.gameObject);
            if (viewers != null)
                viewers.RemoveViewer(currPlatform.gameObject);
            currPlatform.isMoving = !isUsingLeftEye;
            currPlatform = null;
        }

        //Vector2 goalPos = hit.collider == null ? (Vector2)worldMousePosition : hit.transform.position;
        mainPoint.rotation = Quaternion.Euler(new Vector3(0, 0, GetAngle((Vector2)mainPoint.position, worldMousePosition)));
        mainPoint.localPosition = Vector3.zero;

        mainPoint.localScale = transform.localScale;

       // if (hit.collider == null)
        //{
            point.rotation = mainPoint.rotation;
            point.localPosition = defaultPos;
        //}
        //else
        //{
        //    point.localRotation = defaultRot;
        //    point.position = hit.point;
        //}

        Debug.DrawRay(origin, directionRay, Color.red);
    }

    void SwitchEye()
    {
        isUsingLeftEye = !isUsingLeftEye;
        eyeSprite.color = isUsingLeftEye ? eyeCL : eyeCR;
        beam.color = eyeSprite.color;
        particles.startColor = eyeSprite.color;
        animator.SetTrigger("EyeSwap");

        //Update the sprite, however that will be done

        foreach (GameObject movingPlatform in movingPlatforms)
        {
            movingPlatform.gameObject.GetComponent<MovingPlatform>().isMoving = !movingPlatform.gameObject.GetComponent<MovingPlatform>().isMoving;
        }
    }
}
