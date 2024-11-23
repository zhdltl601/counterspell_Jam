using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private PlayerStateMachine StateMachine;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    
    [Header("MoveInfo")]
    public float MoveSpeed;
    public float JumpForce;
    public bool checkGroundBool;
    public LayerMask whatIsGround;
    public Transform checkGroundTrm;
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
        Flip();
        checkGroundBool = CheckGround();

        UI_DebugPlayer.Instance.GetList[0].text = StateMachine.currentState.ToString();
    }
    
    private void Flip()
    {
        Vector3 targetDir = Rigidbody.velocity;
        targetDir.y = 0;
        targetDir.z = 0;
        
        if(targetDir.magnitude == 0)return;
        
        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        transform.rotation = lookDir;
    }

    public void Move(float speed)
    {
        Rigidbody.velocity = new Vector3(speed , Rigidbody.velocity.y , Rigidbody.velocity.z);
    }
    
    public void Jump(float jumpForce)
    {
        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x , jumpForce , Rigidbody.velocity.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(checkGroundTrm.position ,  Vector3.down * checkGroundDistance);

    }

    public bool CheckGround() => Physics.Raycast(checkGroundTrm.position , Vector3.down , checkGroundDistance , whatIsGround);
    

}
