using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerLinker : MonoBehaviour
{
    [SerializeField] private List<UnityEvent> events;
    public void OnTrigger()
    {
        foreach (var item in events)
        {
            item?.Invoke();
        }
    }
}
