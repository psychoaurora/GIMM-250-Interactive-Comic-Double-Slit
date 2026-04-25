using System.ComponentModel;
using UnityEngine;

public class PlayerInfo : MonoBehaviour //This script should probably be attached to the player character and not change across scenes.
{
    public int currentDoor = 1; //Whatever door it is currently in.

    public static PlayerInfo instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
