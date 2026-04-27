using UnityEngine;

public class FloatUpAndDown : MonoBehaviour
{
    [SerializeField] private float bobTime = .5f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector3 floatOffset = Vector3.zero;

    private AnimatedTransition transition;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        transition = new AnimatedTransition(true, bobTime, curve, true, false, -1);
    }
    void FixedUpdate()
    {
        transition.MainUpdate();
        transform.position = Vector3.LerpUnclamped(startPos, startPos + floatOffset, transition.CurrentPosition);
    }
}
