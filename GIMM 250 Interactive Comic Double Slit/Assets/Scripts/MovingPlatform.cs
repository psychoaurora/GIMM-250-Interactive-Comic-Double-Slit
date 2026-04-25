using JetBrains.Annotations;
using UnityEngine;

//I used this: https://www.youtube.com/watch?v=GtX1p4cwYOc video to make this moving platform script. 

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    public bool isMoving = false;



    private int i; //index of array

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = points[startingPoint].position;

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }

    }
}
