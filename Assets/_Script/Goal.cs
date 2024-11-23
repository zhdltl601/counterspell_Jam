using System.Collections;
using System.Collections.Generic;
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
