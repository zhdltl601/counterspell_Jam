using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerableDropper : TriggerableObjectBase, IOnEnterReciver
{
    private bool damaged;
    private Rigidbody rigid;
    [SerializeField] private new MeshRenderer renderer;
    [SerializeField] private Material damagedMaterial;
    [SerializeField] private UnityEvent onDamaged;
    [SerializeField] private UnityEvent onBreak;
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
                if(!damaged)
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
        renderer.material = damagedMaterial;
        Quaternion randomRot = Quaternion.Euler(new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), Random.Range(-2, 3)));
        renderer.transform.rotation = randomRot;
        damaged = true;
        onDamaged.Invoke();
        print("damage");

    }
    private void DropBox()
    {
        rigid.isKinematic = false;
        onBreak.Invoke();
        damaged = false;
        OnTrigger();
        print("box dropped");
    }
}
