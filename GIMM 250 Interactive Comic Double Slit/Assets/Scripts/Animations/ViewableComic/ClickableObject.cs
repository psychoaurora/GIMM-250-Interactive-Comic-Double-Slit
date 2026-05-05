using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public int comicNumber;

    [SerializeField] private UnityEvent onClick;
    private void OnMouseDown()
    {
        if (PauseMenu.GamePaused) return;
        onClick.Invoke();
    }
}
