using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debug
{
    [System.Diagnostics.Conditional("DEBUG")]
    public static void Log(object message)
    {
        UnityEngine.Debug.Log(message);   
    }
}
