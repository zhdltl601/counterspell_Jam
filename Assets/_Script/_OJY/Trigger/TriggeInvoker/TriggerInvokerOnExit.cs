using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvokerOnExit : InvokerBase
{
    private void OnTriggerExit(Collider other)
    {
        InvokeTrigger();
    }
}
