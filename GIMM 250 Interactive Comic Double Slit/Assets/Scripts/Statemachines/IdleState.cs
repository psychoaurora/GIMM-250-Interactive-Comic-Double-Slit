using UnityEngine;

public class IdleState : IPlayerState
{
    private readonly PlayerStateMachine machine;

    public IdleState(PlayerStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        //Maybe start an animation or something
    }

    public void Update()
    {
        if (machine.isGrounded)
        {
            machine.jumps = machine.maxJumps;
        }

        // Check for horizontal movement input
        float input = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(input) > 0.01f)
        {
            machine.SwitchState(new MoveState(machine)); // ? Fixed: specify which state
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && machine.jumps > 0)
        {
            machine.SwitchState(new JumpState(machine)); // ? Added: jump from idle
        }
    }

    public void Exit()
    {
        //Optional cleanup
    }
}
