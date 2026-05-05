using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedEve
{
    public SpriteRenderer eveSprite;
    public AnimatedTransition transition;
}

public class SlowlyShowEves : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    private List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    private List<AnimatedEve> animations = new List<AnimatedEve>();

    private float timer = 0;
    private float timeBetween = 10;

    public bool playing = false;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BackgroundEves");
        foreach (GameObject obj in objs)
        {
            sprites.Add(obj.GetComponent<SpriteRenderer>());
        }
    }

    void Update()
    {
        if (playing)
        {
            if (animations != null)
                foreach(AnimatedEve anim in animations)
                {
                    anim.transition.MainUpdate();
                    anim.eveSprite.color = anim.eveSprite.color.WithAlpha(anim.transition.CurrentPosition);
                }

            timer = Mathf.Clamp(timer - Time.deltaTime, 0, timeBetween);

            if (timer <= 0 && sprites.Count > 0)
            {
                timer = 10;
                timeBetween /= 2;
                AnimatedEve newEve = new AnimatedEve();

                int choice = UnityEngine.Random.Range(0, sprites.Count);
                newEve.eveSprite = sprites[choice];
                newEve.transition = new AnimatedTransition(true, 2, curve);

                sprites.Remove(sprites[choice]);
                animations.Add(newEve);
            }
        }
    }
}
