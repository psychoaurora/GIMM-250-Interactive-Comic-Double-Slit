using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    // THIS CLASS IS MAINLY FOR THE VIDEO CUTSCENE PLAYER.

    //[SerializeField] private UnityEvent onFinished;
    private VideoPlayer videoPlayer;
    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished; // Triggered when the video ends
    }
    private void OnVideoFinished(VideoPlayer vp)
    {
        //Debug.Log("Video has finished playing!");
        // Perform actions like loading a new scene or stopping the player
        vp.Stop();
        EndVideo();
    }

    public void EndVideo()
    {
        SceneManager.LoadScene("Hub World");
    }
}
