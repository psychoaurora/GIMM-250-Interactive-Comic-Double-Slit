using Unity.VisualScripting;
using UnityEngine;

public class PlatformEye : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private Color c1 = Color.yellow;
    [SerializeField] private Color c2 = Color.blue;

    [SerializeField] private bool LeftEyeOnly = false;

    private VisionCheck vision;
    private BoxCollider2D collision;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        vision = GameObject.FindGameObjectWithTag("Player").GetComponent<VisionCheck>();
        collision = GetComponent<BoxCollider2D>();
        if (LeftEyeOnly)
            sprite.color = c1;
        else
            sprite.color = c2;
    }

    private void Update()
    {
        if (vision.isUsingLeftEye != LeftEyeOnly)
        {
            sprite.color = (LeftEyeOnly ? c1 : c2).WithAlpha(.2f);
            collision.enabled = false;
        }
        else
        {
            sprite.color = (LeftEyeOnly ? c1 : c2);
            collision.enabled = true;
        }
    }
}
