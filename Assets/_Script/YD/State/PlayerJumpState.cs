using UnityEngine;

public class PlayerJumpState : PlayerState
{
    private Rigidbody Rigidbody;
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolHash) : base(_player, _stateMachine, _animBoolHash)
    {
        Rigidbody = _player.Rigidbody;
    }

    public override void Enter()
    {
        base.Enter();
        
        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, Player.JumpForce , 0);
    }

    public override void Update()
    {
        base.Update();
        
        Rigidbody.velocity = new Vector3(xInput * Player.MoveSpeed, 0 , 0);

       
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}