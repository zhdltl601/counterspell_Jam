using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InvokerBase : MonoBehaviour
{
    [SerializeField] protected List<UnityEvent> onTriggerEvents;
    protected void InvokeTrigger()
    {
        foreach (var item in onTriggerEvents)
        {
            item.Invoke();
        }
    }
}
