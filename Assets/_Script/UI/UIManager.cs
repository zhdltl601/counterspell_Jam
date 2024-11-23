using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MonoSingletonUsage(MonoSingletonFlags.DontDestroyOnLoad)]
public class UIManager : MonoSingleton<UIManager>
{
    public TitleUI titleUI;
    public DialoguePanel dialoguePanel;

    public static bool fullScreen = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ShowDialoguePanel();
        }
    }

    public void ResetTitle()
    {
        titleUI.ResetUIPosition();
        PopUpManager.Instance.UnloadAllPopUps();
    }

    private void ShowDialoguePanel()
    {
        dialoguePanel.PopUp();
    }
}
