using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableDoor : TriggerableObjectBase, IOnEnterReciver, IOnStayReciver, IOnExitReciver
{
    [SerializeField] private float maxY;
    private Vector3 initialPosition;
    private bool isMoving = false;
    private void Awake()
    {
        initialPosition = transform.position;
    }
    private void Update()
    {
        if (isMoving == false)
            Move(-1);
    }
    public void Move(float yVal)
    {
        Vector3 pos = transform.position + new Vector3(0, Time.deltaTime * yVal);
        pos.y = Mathf.Clamp(pos.y, initialPosition.y, initialPosition.y + maxY);
        transform.position = pos;
    }
    public void OnEnterRecive()
    {
        isMoving = true;
    }
    public void OnStayRecive()
    {
        Move(1);
    }
    public void OnExitRecive()
    {
        isMoving = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, maxY));
    }
}
