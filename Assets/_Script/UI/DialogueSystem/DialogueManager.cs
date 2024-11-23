using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

[MonoSingletonUsage(MonoSingletonFlags.DontDestroyOnLoad)]
public class DialogueManager : MonoSingleton<DialogueManager>
{
    public int CurrentMessageIndex = 0;
    
    public DialogueMessageSO[] dialogueMessages;

    [SerializeField] private TextMeshProUGUI _dialogueText;
    
    public float dialoguePrintSpeed = 0.1f;
    private WaitForSeconds _waitForSeconds;
    
    public Action<bool> OnDialogueEvent;
    
    private bool _isDialogueOpen = false;

    protected override void Awake()
    {
        base.Awake();
        _waitForSeconds = new WaitForSeconds(dialoguePrintSpeed);
        CurrentMessageIndex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _isDialogueOpen = false;
        }
    }

    public void StartDialogue()
    {
        StartCoroutine(nameof(PrintDialogue));
    }
    
    private IEnumerator PrintDialogue()
    {
        if (dialogueMessages.Length == CurrentMessageIndex)
        {
            OnDialogueEvent?.Invoke(_isDialogueOpen);
            yield break;
        }
        
        _isDialogueOpen = true;
        OnDialogueEvent?.Invoke(_isDialogueOpen);
        _dialogueText.text = ""; 
        StringBuilder builder = new StringBuilder();
        
        for (int i = 0; i < dialogueMessages[CurrentMessageIndex].message.Length; i++)
        {
            builder.Append(dialogueMessages[CurrentMessageIndex].message[i]);

            if (_isDialogueOpen == false)
            {
                _dialogueText.text = dialogueMessages[CurrentMessageIndex].message;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                CurrentMessageIndex++;
                OnDialogueEvent?.Invoke(_isDialogueOpen);
                yield break;
            }
            
            _dialogueText.text = builder.ToString();
            yield return _waitForSeconds;
        }
        
        _isDialogueOpen = false;
        CurrentMessageIndex++;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        
        OnDialogueEvent?.Invoke(_isDialogueOpen);
    }
}
