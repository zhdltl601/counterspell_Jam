using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour, IOnEnterReciver
{
    private void Start()
    {
        print(name);
        GameManager.IncreaseMaxGoalCount();

        transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental) 
            .SetEase(Ease.Linear);         
        
        
        transform.DOMoveY(transform.position.y + 0.5f, 1f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
    public void OnEnterRecive()
    {
        GameManager.OnGoal();
    }

    
}
