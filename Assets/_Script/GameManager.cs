using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private ColliderActiver aColliderActiver;
    private static int goalCount;
    private static int maxGoal;
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
            Instance.HiglightPointA();
        }
    }
    public void HiglightPointA()
    {
        print("ha");
        aColliderActiver.SetColliderActive(true);
    }

}
