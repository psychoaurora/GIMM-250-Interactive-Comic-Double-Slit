using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour/*, IInteractable*/
{
    //Order of operations:
    //When you are in range of a door, check what type of door it is and store that information. This should be automatic
    //If you press E and are in range of a door, go through that door. If you are not in range, don't do anything.
    //When you interact, send the information about the current door. If the current door does not go to the hub world,
    //then go to gameplay section with whatever current door it is. So at first it will be 1 (or 0) and will load the first scene/gameplay section
    //If it goes to the hub world door then check if that door has a position that is bigger than the current position in the current door array.
    //If it is bigger (by 1), then add 1 to the current door position. Then update the door sprites 

    

    protected virtual void Interact()
    {

    }

    protected virtual void Enter()
    {

    }
}

