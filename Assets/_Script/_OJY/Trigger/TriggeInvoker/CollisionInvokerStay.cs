using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInvokerStay : InvokerBase
{
    private void OnCollisionStay(Collision collision)
    {
        InvokeTrigger();
    }
}
