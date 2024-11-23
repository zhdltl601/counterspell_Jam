using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    private PlayerStateMachine StateMachine;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    
    [Header("MoveInfo")]
    public float MoveSpeed;
    public float JumpForce;
    public LayerMask whatIsGround;
    public Transform checkGround;
    public float checkGroundDistance;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        
        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(PlayerStateEnum.Idle , new PlayerIdleState(this , StateMachine , "Idle"));
        StateMachine.AddState(PlayerStateEnum.Run , new PlayerMoveState(this , StateMachine , "Move"));
        StateMachine.AddState(PlayerStateEnum.Jump , new PlayerJumpState(this , StateMachine , "Jump"));
        StateMachine.AddState(PlayerStateEnum.Falling , new PlayerFallingState(this , StateMachine , "Falling"));
                
        StateMachine.Init(PlayerStateEnum.Idle);
            
    }
            
    private void Update()
    {
        StateMachine.currentState.Update();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(checkGround.position ,  Vector3.down * checkGroundDistance);

    }

    public bool CheckGround() => Physics.Raycast(checkGround.position , Vector3.down , checkGroundDistance , whatIsGround);
    

}
