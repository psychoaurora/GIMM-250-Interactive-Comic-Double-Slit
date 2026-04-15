using UnityEngine;

public class JumpState : IPlayerState
{
    private readonly PlayerStateMachine machine;

    public JumpState(PlayerStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered Jump state");
        machine.rb.linearVelocity = new Vector2(machine.rb.linearVelocity.x, machine.JumpForce);

        machine.jumps--;
    }

    public void Update()
    {
        // Allow air control
        float input = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(input * machine.HorizontalSpeed, machine.rb.linearVelocity.y);
        machine.rb.linearVelocity = movement;

        // Flip sprite based on direction
        if (input < 0)
        {
            machine.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (input > 0)
        {
            machine.transform.localScale = new Vector3(1, 1, 1);
        }

        if (machine.isGrounded && machine.rb.linearVelocity.y <= .01f)
        {
            machine.jumps = machine.maxJumps;
            Debug.Log("Landed");

            if (Mathf.Abs(input) < .01f)
            {
                machine.SwitchState(new IdleState(machine));
            }
            if (Input.GetButtonDown("Jump"))
            {
                machine.SwitchState(new JumpState(machine));
            }
        }
    }

    public void Exit()
    {
        //Optional cleanup
        //Probably stop animation here
    }

}
