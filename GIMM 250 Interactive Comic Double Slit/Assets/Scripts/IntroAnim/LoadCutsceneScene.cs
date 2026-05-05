using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCutsceneScene : MonoBehaviour
{
    [SerializeField] private string SceneName = "";
    public void LoadCutscene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
