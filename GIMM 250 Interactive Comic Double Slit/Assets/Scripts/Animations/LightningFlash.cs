using UnityEngine;

public class LightningFlash : MonoBehaviour
{
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private Color flashColor;
    [SerializeField] private Color normalColor;

    [SerializeField] private float flashTime = 1f;
    [SerializeField] private AnimationCurve flashCurve;

    private SpriteRenderer sprite;
    private AnimatedTransition transition;

    private float timer = 10f;

    void UpdateTimer() => timer = Random.Range(minTime, maxTime);
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();   
        UpdateTimer();

        transition = new AnimatedTransition(true, flashTime, flashCurve, false, false);
    }
    void Update()
    {
        timer = Mathf.Clamp(timer - Time.deltaTime, 0, maxTime);
        transition.MainUpdate();

        sprite.color = Color.LerpUnclamped(flashColor, normalColor, transition.CurrentPosition);

        if (timer <= 0)
        {
            transition.Playing = true;
            UpdateTimer();
        }
    }
}
