using UnityEngine;

public class HordeObjectMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Vector3 movement;
    private BoxCollider2D boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //horde moves to the right
        movement = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: move object
        //Debug.Log("i exist");
        transform.position += movement * movementSpeed;

    }



}
