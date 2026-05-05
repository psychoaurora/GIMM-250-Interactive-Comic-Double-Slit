using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    GlobalHelper globalHelper;

    [SerializeField] private GameObject videoCan;
    [SerializeField] private RawImage videoImg;
    [SerializeField] private SlowlyShowEves eveFadeIns;

    [SerializeField] private AnimationCurve curve;

    [SerializeField] private string finalScene;

    private AnimatedTransition videoFade;
    private GlobalHelper helper;

    public void StartOutro()
    {
        videoFade = new AnimatedTransition(false, 32, curve);
        Invoke("StartVideo", 1);
        Invoke("FadeVideo", 28);
        Invoke("FadeEves", 30);
        Invoke("EndGame", 44);
    }

    public void StartVideo()
    {
        videoCan.SetActive(true);
    }

    public void FadeVideo()
    {
        videoFade.Playing = true;
    }

    public void FadeEves()
    {
        eveFadeIns.playing = true;
    }

    public void EndGame()
    {
        helper = GameObject.FindGameObjectWithTag("GlobalHelper").GetComponent<GlobalHelper>();
        helper.ResetPlayerInfo();
        SceneManager.LoadScene(finalScene);
    }

    private void Update()
    {
        if (videoFade != null)
        {
            videoFade.MainUpdate();
            videoImg.color = videoImg.color.WithAlpha(1 - videoFade.CurrentPosition);
        }
    }
}
