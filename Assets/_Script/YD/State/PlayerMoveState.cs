using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private Rigidbody Rigidbody;
    
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolHash) : base(_player, _stateMachine, _animBoolHash)
    {
        Rigidbody = Player.Rigidbody;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        Flip();
        
        if (xInput == 0.0f)
        {
            StateMachine.ChangeState(PlayerStateEnum.Idle);
        }
        
        Rigidbody.velocity = new Vector3(xInput * Player.MoveSpeed, 0 , 0);
        Animator.SetFloat("Speed" , Mathf.Abs(xInput));
    }

    private void Flip()
    {
        Quaternion lookDir = Quaternion.LookRotation(Rigidbody.velocity);
        Player.transform.rotation = lookDir;
    }

    public override void Exit()
    {
        base.Exit();
    }
}