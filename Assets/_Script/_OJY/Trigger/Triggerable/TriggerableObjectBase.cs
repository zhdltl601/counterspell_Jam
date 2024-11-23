using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class TriggerableObjectBase : MonoBehaviour
{
    [SerializeField] private List<UnityEvent> events;
    public virtual void OnTrigger()
    {
        foreach (var item in events)
        {
            item?.Invoke();
        }
    }
}
