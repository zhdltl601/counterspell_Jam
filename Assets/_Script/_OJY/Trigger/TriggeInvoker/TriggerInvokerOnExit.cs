using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvokerOnExit : TriggerInvokerBase
{
    private void OnTriggerExit(Collider other)
    {
        InvokeTrigger();
    }
}
