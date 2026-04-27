using UnityEngine;

public class FloatUpAndDown : MonoBehaviour
{
    [SerializeField] private float bobTime = .5f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector2 floatOffset = Vector2.zero;

    private AnimatedTransition transition;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
        transition = new AnimatedTransition(true, bobTime, curve, true, false, -1);
    }
    void FixedUpdate()
    {
        transition.MainUpdate();
        transform.position = Vector2.LerpUnclamped(startPos, startPos + floatOffset, transition.CurrentPosition);
    }
}
