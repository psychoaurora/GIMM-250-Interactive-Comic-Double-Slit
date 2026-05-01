using UnityEngine;

public class ScaleUpAndDown : MonoBehaviour
{
    private AnimatedTransition transition;

    [SerializeField] private float scaleEnd = 5f;
    [SerializeField] private float transTime = 1f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private SpriteRenderer colorCopy;
    private SpriteRenderer sprite;

    public bool playing;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transition = new AnimatedTransition(false, transTime, curve, false, true);
    }
    private void Update()
    {
        sprite.color = new Color(colorCopy.color.r, colorCopy.color.g, colorCopy.color.b, .3f);
        transition.Playing = playing;
        transition.MainUpdate();
        transform.localScale = Vector3.one * scaleEnd * (transition.CurrentPosition);
    }
}
