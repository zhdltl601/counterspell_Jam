using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Message", menuName = "SO/DialogueMessage")]
public class DialogueMessageSO : ScriptableObject
{
    [Multiline]
    public string message;
}
