using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableDoor : TriggerableObjectBase
{
    public override void OnTrigger()
    {
        base.OnTrigger();
        print("door opens");
    }
}
