using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInvokerEnter : InvokerBase
{
    private void OnCollisionEnter(Collision collision)
    {
        InvokeTrigger();
    }
}
