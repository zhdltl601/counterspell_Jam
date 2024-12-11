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
        GameManager.IncreaseMaxGoalCount();
    }
    public void OnEnterRecive()
    {
        GameManager.OnGoal();
    }

    
}
