using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent onClick;
    private void OnMouseDown()
    {
        onClick.Invoke();
    }
}
