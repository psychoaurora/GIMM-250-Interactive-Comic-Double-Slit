using UnityEngine;

public class AnimatedTransition
{
    public float TransitionTime { get; set; }
    public AnimationCurve Curve { get; set; }
    public bool Reverses { get; set; }
    public bool ReverseWhenPlayingStops { get; set; }
    public int RepeatCount { get; set; }
    public float CurrentPosition
    {
        get
        {
            return currentPosition;
        }
        set
        {
            currentPosition = value;
        }
    }
    public bool Paused
    {
        get
        {
            return paused;
        }
        set
        {
            paused = value;
        }
    }
    public bool Playing 
    {
        get
        {
            return playing;
        }
        set
        {
            playing = value;
        }
    }
    private int CurrentRepeat
    {
        get
        {
            return currRepeat;
        }
        set
        {
            if (currRepeat != -1)
            {

                if (value > RepeatCount && !ReverseWhenPlayingStops)
                {
                    playing = false;
                    currRepeat = 0;
                    Debug.Log("Stopped");
                }
                else if (value <= RepeatCount)
                {
                    currRepeat = value;
                    timeElapsed = 0;
                }

                //Debug.Log(currRepeat);
                //Debug.Log(playing);
            }
        }
    }

    private float currentPosition = 0;
    private float timeElapsed = 0;
    private int currRepeat = 0;

    private bool reversing = false;
    private bool paused = false;
    private bool playing = false;

    public static AnimationCurve defaultCurve = new AnimationCurve();

    //CONSTUCTOR
    public AnimatedTransition(bool playing, float transitionTime, AnimationCurve curve, bool reverses, bool reverseOnStop, int repeatCount)
    {
        this.Playing = playing;
        this.TransitionTime = transitionTime;
        this.Curve = curve;
        this.Reverses = reverses;
        this.ReverseWhenPlayingStops = reverseOnStop;
        this.RepeatCount = repeatCount;
    }

    #region Extra Constructors
    public AnimatedTransition(bool playing) : this(playing, 1f, defaultCurve, false, true, 0) { }
    public AnimatedTransition(bool playing, float transitionTime) : this(playing, transitionTime, defaultCurve, false, true, 0) { }
    public AnimatedTransition(bool playing, float transitionTime, AnimationCurve curve) : this(playing, transitionTime, curve, false, true, 0) { }
    public AnimatedTransition(bool playing, float transitionTime, AnimationCurve curve, bool reverses) : this(playing, transitionTime, curve, reverses, false, 0) { }
    public AnimatedTransition(bool playing, float transitionTime, AnimationCurve curve, bool reverses, bool reverseOnStop) : this(playing, transitionTime, curve, reverses, reverseOnStop, 0) { }
    #endregion

    private void UpdatePosition(float delta)
    {
        //Debug.Log($"delta is {delta}");
        //Debug.Log($"timeElapsed before update is {timeElapsed} and new time elapsed will be {Mathf.Clamp(timeElapsed + delta, 0, 1)}");
        timeElapsed = Mathf.Clamp(timeElapsed + delta, 0, 1);
        currentPosition = Curve.Evaluate(timeElapsed);
    }

    public void MainUpdate()
    {
        if (paused) return;

        //Debug.Log(playing);
        //Debug.Log(timeElapsed);

        float delta = Time.fixedDeltaTime/TransitionTime;

        if (RepeatCount == -1)
            currRepeat = -1;

        if (!playing)
        {
            reversing = false;
            currRepeat = 0;
            if (ReverseWhenPlayingStops && timeElapsed > 0)
            {
                delta *= -1;
            }
            else
            {
                timeElapsed = 0;
                return;
            }
        }
        else
        {
            if (timeElapsed >= 1)
            {
                if (Reverses)
                    reversing = true;
                else
                    CurrentRepeat = CurrentRepeat + 1;
            }
            else if (reversing && timeElapsed <= 0)
            {
                CurrentRepeat = CurrentRepeat + 1;
                reversing = false;
            }

            if (playing) delta *= reversing ? -1 : 1;
            else delta = 0;
        }

        //Debug.Log($"Delta is: {delta}");
        UpdatePosition(delta);
    }
}
