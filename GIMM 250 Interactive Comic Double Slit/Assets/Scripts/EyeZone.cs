using UnityEngine;

public class EyeZone : MonoBehaviour
{
    private BoxCollider2D collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.gameObject.GetComponent<VisionCheck>().eyeActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.gameObject.GetComponent<VisionCheck>().eyeActive = false;
    }
}
