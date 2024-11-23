using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    A,
    B
}
public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private ColliderActiver aColliderActiver;
    private static int goalCount;
    private static int maxGoal;
    public static event Action OnBReached;
    public static GameState CurrentState { get; private set; } = GameState.A;
    
    public static void IncreaseMaxGoalCount()
    {
        maxGoal++;
        print("maxGoal" + maxGoal);
    }
    public static void OnGoal()
    {
        goalCount++;
        bool isVisitedAllGoal = goalCount == maxGoal - 1;
        if (isVisitedAllGoal)
        {
            OnBReached?.Invoke();
            CurrentState = GameState.B;
            Instance.HiglightPointA();
        }
    }
    private void HiglightPointA()
    {
        print("ha");
        aColliderActiver.SetColliderActive(true);
    }
}
