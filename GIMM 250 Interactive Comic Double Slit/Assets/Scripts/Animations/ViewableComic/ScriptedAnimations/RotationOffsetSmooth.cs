using Unity.Mathematics;
using UnityEngine;

public class RotationOffsetSmooth : MonoBehaviour
{
    [SerializeField] private float bobTime = .5f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector3 rotationOffset = Vector3.zero;

    private AnimatedTransition transition;
    private Quaternion startRot;
    private Quaternion endRot;

    void Start()
    {
        startRot = transform.rotation;
        endRot = Quaternion.FromToRotation(startRot.eulerAngles, 
            new Vector3(Mathf.Deg2Rad*rotationOffset.x, Mathf.Deg2Rad*rotationOffset.y, Mathf.Deg2Rad*rotationOffset.z));
        transition = new AnimatedTransition(true, bobTime, curve, true, false, -1);
    }
    void FixedUpdate()
    {
        transition.MainUpdate();
        transform.rotation = Quaternion.LerpUnclamped(startRot, endRot, transition.CurrentPosition);
    }
}
