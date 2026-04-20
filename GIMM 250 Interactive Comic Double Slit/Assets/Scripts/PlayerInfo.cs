using UnityEngine;

public class PlayerInfo : MonoBehaviour //This script should probably be attached to the player character and not change across scenes.
{

    //We want the doors to unlock one after another (besides the last one)
    //I think we should have two arrays of doors. I think they should be parallel.
    //One array will be hub world doors and the other will be gameplay doors
    //When you go finish a world (go through a door in that gameplay section), it will check
    //where you are in the array. If the door you went through is less than the current array
    //position, then go up one in the array. Either when you go back to hub world or in Update,
    //update the current door.

    

    public GameObject[] hubWorldDoors = new GameObject[4];
    public GameObject[] gameplayDoors = new GameObject[3];
    //Parallel arrays. First door in the hub world has the first door in the gameplay section.

    public int currentDoor = 1; //Whatever door it is currently in.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
