using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/DeadDescription")]
public class DeadDescriptinSO : ScriptableObject
{
    [TextArea]public string[] descriptions;

    public string GetDescription()
    {
        return descriptions[Random.Range(0, descriptions.Length)];
    }
    
    
}
