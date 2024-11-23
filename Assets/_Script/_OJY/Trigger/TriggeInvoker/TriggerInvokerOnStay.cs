using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvokerOnStay : InvokerBase
{
    private void OnTriggerStay(Collider other)
    {
        InvokeTrigger();
    }
}
