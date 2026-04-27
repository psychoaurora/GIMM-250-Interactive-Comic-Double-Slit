using UnityEngine;

public class ActiveOnAwake : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    void Start()
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
