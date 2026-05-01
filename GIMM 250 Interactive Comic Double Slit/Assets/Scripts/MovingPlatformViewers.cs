using UnityEngine;
using System;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class MovingPlatformView
{
    public MovingPlatformView(GameObject obj, ScaleUpAndDown circ)
    {
        objToTrack = obj;
        currentCircle = circ;
    }
    public GameObject objToTrack;
    public ScaleUpAndDown currentCircle;
}
public class MovingPlatformViewers : MonoBehaviour
{
    [SerializeField] private List<ScaleUpAndDown> circles;

    private List<MovingPlatformView> views;

    private bool AlreadyViewer(GameObject nobj)
    {
        foreach(MovingPlatformView view in views)
        {
            if (nobj == view.objToTrack)
                return true;
        }
        return false;
    }
    public void AddViewer(GameObject nobj)
    {
        if (!AlreadyViewer(nobj))
            foreach (ScaleUpAndDown circ in circles)
            {
                if (!circ.playing)
                {
                    MovingPlatformView view = new MovingPlatformView(nobj, circ);
                    circ.playing = true;
                    views.Add(view);
                    break;
                }
            }
    }

    public void RemoveViewer(GameObject nobj)
    {
        if (!AlreadyViewer(nobj))
            return;
        foreach (MovingPlatformView view in views)
        {
            if (nobj == view.objToTrack)
            {
                view.currentCircle.playing = false;
                views.Remove(view);
                view.objToTrack = null;
                view.currentCircle = null;
                break;
            }
        }
    }

    private void Start()
    {
        views = new List<MovingPlatformView>();
    }

    private void Update()
    {
        foreach (MovingPlatformView view in views)
        {
            view.currentCircle.transform.position = view.objToTrack.transform.position;
        }
    }
}
