using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    A,
    B
}
public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private ColliderActiver aColliderActiver;
    [field: SerializeField] private static int goalCount;
    [field: SerializeField] private static int maxGoal = 0;
    public static event Action OnBReached;
    public static GameState CurrentState { get; private set; } = GameState.A;
    public bool isTitle = true;

    public static bool isFirstScene = true;
    public static int CurrentSceneIndex { get; private set; } = 0;
    public static void OnSceneFinished()
    {
        maxGoal = 0;
        goalCount = 0;
        SetStateToAState();
        int nextSceneIndex = CurrentSceneIndex + 1;
        CurrentSceneIndex = nextSceneIndex;
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    public static void IncreaseMaxGoalCount()
    {
        maxGoal = Mathf.Clamp(maxGoal, maxGoal + 1, 2);
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

    public static void SetStateToAState()
    {
        CurrentState = GameState.A;
    }
    
    private void HiglightPointA()
    {
        aColliderActiver.SetColliderActive(true);
    }
}
