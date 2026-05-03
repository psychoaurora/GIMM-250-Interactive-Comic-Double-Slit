using UnityEngine;

public class HordeObjectMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private ParticleSystem particles;
    private Vector3 movement;
    private BoxCollider2D boxCollider;
    private VisionCheck checker;

    private bool eyeColor = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //horde moves to the right
        movement = new Vector3(1, 0, 0);
        checker = GameObject.FindGameObjectWithTag("Player").GetComponent<VisionCheck>();
        eyeColor = !checker.isUsingLeftEye;

        GetComponent<SpriteRenderer>().color = !checker.isUsingLeftEye ? Color.yellow : Color.blue;
        particles.startColor = !checker.isUsingLeftEye ? Color.yellow : Color.blue;
        particles.Emit(20);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: move object
        //Debug.Log("i exist");
        transform.position += movement * movementSpeed;
        if (checker.isUsingLeftEye == eyeColor)
        {
            gameObject.SetActive(false);
        }

    }



}
