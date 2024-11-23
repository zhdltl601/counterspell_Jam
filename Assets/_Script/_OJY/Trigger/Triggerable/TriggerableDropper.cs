using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableDropper : TriggerableObjectBase, IOnEnterReciver
{
    private bool damaged;
    private Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }
    public void OnEnterRecive()
    {
        var gameState = GameManager.CurrentState;
        switch (gameState)
        {
            case GameState.A:
                DamageBox();
                break;
            case GameState.B:
                if (damaged)
                    DropBox();
                break;
        }
    }

    private void DamageBox()
    {
        damaged = true;
        print("damage");
    }
    private void DropBox()
    {
        rigid.isKinematic = false;
        OnTrigger();
        print("box dropped");
    }
}
