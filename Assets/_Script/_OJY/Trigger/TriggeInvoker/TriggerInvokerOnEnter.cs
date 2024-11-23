using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvokerOnEnter : TriggerInvokerBase
{
    private void OnTriggerEnter(Collider other)
    {
        InvokeTrigger();
    }
}
