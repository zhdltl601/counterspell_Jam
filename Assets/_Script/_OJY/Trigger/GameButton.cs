using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour, IOnEnterReciver, IOnStayReciver, IOnExitReciver
{
    [SerializeField] private Transform targetTransform;
    
    [SerializeField] private float sizeY;
    [SerializeField] private float multiplier = 4.5f;
    
    private Vector3 initialScale;
    private bool isMoving = false;
    
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
        Vector3 size = targetTransform.localScale - new Vector3(0, Time.deltaTime * scale * multiplier);
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
