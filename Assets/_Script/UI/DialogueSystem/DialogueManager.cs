using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

//[MonoSingletonUsage(MonoSingletonFlags.DontDestroyOnLoad)]
public class DialogueManager : MonoSingleton<DialogueManager>
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    
    public float dialoguePrintSpeed = 0.1f;
    private WaitForSeconds _waitForSeconds;
    
    public Action<bool> OnDialogueEvent;
    
    private bool _isDialogueOpen = false;

    protected override void Awake()
    {
        base.Awake();
        _waitForSeconds = new WaitForSeconds(dialoguePrintSpeed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _isDialogueOpen = false;
        }
    }

    public void StartDialogue(DialogueMessageSO dialogueMessage)
    {
        StopAllCoroutines();
        StartCoroutine(PrintDialogue(dialogueMessage));
    }
    public void StartDialogueOjy(string str)
    {
        StopAllCoroutines();
        StartCoroutine(PrintDialogueOJY(str));
    }
    private IEnumerator PrintDialogueOJY(string dialogueMessage)
    {
        _isDialogueOpen = true;
        OnDialogueEvent?.Invoke(_isDialogueOpen);
        _dialogueText.text = "";
        StringBuilder builder = new StringBuilder();

        {
            builder.Append(dialogueMessage);

            if (_isDialogueOpen == false)
            {
                _dialogueText.text = dialogueMessage;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                OnDialogueEvent?.Invoke(_isDialogueOpen);
                yield break;
            }

            _dialogueText.text = builder.ToString();
            _audioSource.Play();
            yield return _waitForSeconds;
        }

        _isDialogueOpen = false;

        yield return new WaitForSeconds(5f);
        OnDialogueEvent?.Invoke(_isDialogueOpen);
    }
    private IEnumerator PrintDialogue(DialogueMessageSO dialogueMessage)
    {
        _isDialogueOpen = true;
        OnDialogueEvent?.Invoke(_isDialogueOpen);
        _dialogueText.text = ""; 
        StringBuilder builder = new StringBuilder();
        
        for (int i = 0; i < dialogueMessage.message.Length; i++)
        {
            builder.Append(dialogueMessage.message[i]);

            if (_isDialogueOpen == false)
            {
                _dialogueText.text = dialogueMessage.message;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                OnDialogueEvent?.Invoke(_isDialogueOpen);
                yield break;
            }
            
            _dialogueText.text = builder.ToString();
            _audioSource.Play();
            yield return _waitForSeconds;
        }
        
        _isDialogueOpen = false;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnDialogueEvent?.Invoke(_isDialogueOpen);
            yield break;
        }
        
        yield return new WaitForSeconds(2f);
        OnDialogueEvent?.Invoke(_isDialogueOpen);
    }
}
