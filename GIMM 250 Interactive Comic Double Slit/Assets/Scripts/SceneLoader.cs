using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string sceneName;
    
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
