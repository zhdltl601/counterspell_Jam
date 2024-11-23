using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvokerOnStay : TriggerInvokerBase
{
    private void OnTriggerStay(Collider other)
    {
        InvokeTrigger();
    }
}
