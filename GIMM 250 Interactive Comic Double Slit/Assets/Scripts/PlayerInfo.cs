using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assemblies;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerInfo : MonoBehaviour //This script should probably be attached to the player character and not change across scenes.
{
    [SerializeField] int currentDoor = 1; //Whatever door it is currently in.
    [SerializeField] int currentComic = 1; //Whatever comic the player is on

    private int keyFragment = 0;

    private const int FINALDOOR = 4;

    GameObject globalHelperObject;
    GlobalHelper globalHelper;

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

        globalHelperObject = GameObject.FindGameObjectWithTag("GlobalHelper");
        globalHelper = globalHelperObject.GetComponent<GlobalHelper>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ONLY FOR DEBUGGING
        if (Input.GetKeyDown(KeyCode.F))
        {
            KeyFragment++;
            Debug.Log("Incremented keyfrag");
        }
    }

    public int CurrentDoor
    {
        get
        { return currentDoor; }
        set
        {
            currentDoor = value;
            CurrentComic = value++;
        }
    }

    public int CurrentComic
    {
        get { return currentComic; }
        set
        {
            currentComic = value;
            //Update the current Comic for the interactive feature
        }
    }

    public int KeyFragment
    {
        get
        {
            return keyFragment;
        }
        set
        {
            keyFragment = value;
            if (KeyFragment == 3)
            {
                globalHelper.UpdateGate();
            }
        }
    }
}
