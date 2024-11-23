using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvokerOnEnter : InvokerBase
{
    private void OnTriggerEnter(Collider other)
    {
        InvokeTrigger();
    }
}
