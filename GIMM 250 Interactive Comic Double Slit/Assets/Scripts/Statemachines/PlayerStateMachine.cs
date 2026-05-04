using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    [Header("Movement properties")]
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpForce;

    [Header("Movement step rate")]
    [SerializeField] private float movementFps = 12f;

    private IPlayerState currentState;

    [HideInInspector] public Rigidbody2D rb;

    public bool isGrounded;
    public int jumps = 1;
    public int maxJumps = 1;


    public float StepInterval => 1f / movementFps;

    public Vector3 startPosition;

    void Start()
    {
        SwitchState(new IdleState(this));
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
        // Debug.Log(startPosition);
        CheckGround();
    }

    public void SwitchState(IPlayerState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    //Accessors
    public Transform GetTransform() => transform;
    public float HorizontalSpeed
    {
        set
        {
            horizontalSpeed = value;
        }
        get
        {
            return horizontalSpeed;
        }
    }
    public float JumpForce
    {
        set
        {
            jumpForce = value;
        }
        get
        {
            return jumpForce;
        }
    }

    public void CheckGround()
    {
        float radius = .1f; // The radius of the circle cast
        float distance = 1.1f; // The distance of the circle cast
        Vector2 origin = transform.position; // The position of the ground check object
        Vector2 direction = Vector2.down; // The direction of the raycast
        LayerMask layerMask = LayerMask.GetMask("Ground", "Platform", "Wall"); // The layers the raycast should hit

        /* CircleCast is a 2D sphere cast that checks for colliders in a circular area.
            RaycastHit2D is a struct that stores information about the raycast hit. 
            Raycasts are basically invisible rays that are used to detect objects in the scene. */
        RaycastHit2D hit = Physics2D.CircleCast(origin, radius, direction, distance, layerMask);

        // If the raycast hits a collider, the player is grounded. Otherwise, the player is not grounded.
        if (hit.collider != null)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }

        Debug.DrawRay(origin, direction * distance, Color.red);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("HordeObject"))
        {
            //reset player to start
            Debug.Log("uh oh, moving player to start");
            transform.position = startPosition;
        }
        Debug.Log(other.gameObject.tag);
    }
}

