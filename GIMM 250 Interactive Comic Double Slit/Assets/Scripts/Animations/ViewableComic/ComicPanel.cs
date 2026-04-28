using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ComicPanel : MonoBehaviour
{
    [SerializeField] GameObject blindImage;

    [Header("Animation Properties")]
    [SerializeField] float endScale = 4f;
    [SerializeField] float scaleTime = 1f;
    [SerializeField] AnimationCurve curve;
    [SerializeField] bool notAnimated = false;

    [Header("Panel Status")]
    public bool isOpen { 
        get
        {
            return isopen;
        }
        set
        {
            isopen = value;
            if (transition != null)
                transition.Playing = value;
            UpdatePanel();
        }
    }
    public bool mysteriousOoooo = false;

    [Header("Panel Events")]
    public UnityEvent panelOpened;
    public UnityEvent panelClosed;

    Vector2 startPos = Vector2.zero;
    Vector3 startScale = Vector3.zero;
    AnimatedTransition transition;

    RectTransform blindRect;
    RectTransform panelRect;
    

    private bool isopen = false;
    public void UpdatePanel()
    {
        if (isopen) panelOpened.Invoke();
        else panelClosed.Invoke();
    }

    void Start()
    {
        transition = new AnimatedTransition(false, scaleTime, curve, false, true);
        startPos = transform.localPosition;
        startScale = transform.localScale;

        blindRect = blindImage.GetComponent<RectTransform>();
        panelRect = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        blindImage.SetActive(mysteriousOoooo);

        blindRect.sizeDelta = panelRect.sizeDelta;

        transition.Playing = isopen;
        transition.MainUpdate();

        if (!notAnimated)
        {
            float curvePos = transition.CurrentPosition;

            transform.localPosition = Vector2.LerpUnclamped(startPos, Vector2.zero, curvePos);
            transform.localScale = Vector3.LerpUnclamped(startScale, Vector3.one * endScale, curvePos);
        }
        else
        {
            transform.localPosition = isopen ? Vector2.zero : startPos;
            transform.localScale = isopen ? Vector2.one * endScale : startScale;
        }
    }
}
