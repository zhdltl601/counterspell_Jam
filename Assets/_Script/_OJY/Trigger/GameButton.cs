using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour, IOnEnterReciver, IOnStayReciver, IOnExitReciver
{
    [SerializeField] private float sizeY;
    private Vector3 initialScale;
    private bool isMoving = false;
    [SerializeField] private Transform targetTransform;
    private void Awake()
    {
        initialScale = targetTransform.localScale;
    }
    private void Update()
    {
        if (isMoving == false)
            Size(-1);
    }
    public void Size(float scale)
    {
        Vector3 size = targetTransform.localScale - new Vector3(0, Time.deltaTime * scale);
        size.y = Mathf.Clamp(size.y, sizeY, initialScale.y);
        targetTransform.localScale = size;
    }
    public void OnEnterRecive()
    {
        isMoving = true;
    }
    public void OnStayRecive()
    {
        Size(1);
    }
    public void OnExitRecive()
    {
        isMoving = false;
    }
}
