using UnityEngine;
using UnityEngine.UI;

public class TransparencyTransition : MonoBehaviour
{
    [SerializeField] private float transitionTime = .5f;
    [SerializeField] private AnimationCurve curve;

    private AnimatedTransition transition;
    private RawImage img;
    private Color imgColor;
    private Color colorGoal;

    public bool Playing
    {
        set
        {
            playing = value;
        }
        get
        {
            return playing;
        }
    }

    //public void SetPlaying(bool isplaying)
    //{
    //    Playing = isplaying;
    //}

    [SerializeField] private bool playing = false;

    private void Start()
    {
        img = GetComponent<RawImage>();
        imgColor = img.color;
        colorGoal = new Color(imgColor.r, imgColor.g, imgColor.b, 0);
        transition = new AnimatedTransition(false, transitionTime, curve, false, true);
    }

    private void FixedUpdate()
    {
        transition.Playing = playing;
        transition.MainUpdate();
        img.color = Color.Lerp(colorGoal, imgColor, transition.CurrentPosition);
    }
}
