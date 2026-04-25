using System.Threading;
using UnityEngine;

public class MoveState : IPlayerState
{
    private readonly PlayerStateMachine machine;

    public MoveState(PlayerStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered Move State");
        //Maybe start an animation in here or something
    }

    public void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(input * machine.HorizontalSpeed, machine.rb.linearVelocity.y);
        machine.rb.linearVelocity = movement;

        if (input < 0)
        {
            machine.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (input > 0)
        {
            machine.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Mathf.Abs(input) < .01f)
        {
            machine.SwitchState(new IdleState(machine));
        }
        if (Input.GetButtonDown("Jump"))
        {
            machine.SwitchState(new JumpState(machine));
        }
    }

    public void Exit()
    {
        //Optional cleanup
        //Probably stop playing anim here
    }
}
