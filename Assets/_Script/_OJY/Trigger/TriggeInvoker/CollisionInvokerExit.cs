using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInvokerExit : InvokerBase
{
    private void OnCollisionExit(Collision collision)
    {
        InvokeTrigger();
    }
}
