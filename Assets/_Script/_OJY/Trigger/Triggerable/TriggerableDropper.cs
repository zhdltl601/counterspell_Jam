using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableDropper : TriggerableObjectBase, IOnEnterReciver, IOnExitReciver
{
    private bool damaged;
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
    public void OnExitRecive()
    {
        print("exot");
    }
    private void DamageBox()
    {
        damaged = true;
        print("damage");
    }
    private void DropBox()
    {
        print("box dropped");
    }
}
