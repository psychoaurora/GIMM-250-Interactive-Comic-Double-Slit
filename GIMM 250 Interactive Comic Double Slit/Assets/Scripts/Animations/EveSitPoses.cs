using UnityEngine;

public class EveSitPoses : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteComponents;
    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        Sprite spriteChoice = sprites[Random.Range(0, sprites.Length)];
        foreach (SpriteRenderer sprite in spriteComponents)
            sprite.sprite = spriteChoice;
    }
}
