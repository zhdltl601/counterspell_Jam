using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerInvokerBase : MonoBehaviour
{
    protected TriggerLinker triggerBase;
    private void Awake()
    {
        triggerBase = GetComponentInChildren<TriggerLinker>();
    }
    protected void InvokeTrigger()
    {
        triggerBase.OnTrigger();
    }
}
