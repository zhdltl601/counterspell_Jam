using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DialoguePanel : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    private void Start()
    {
        DialogueManager.Instance.OnDialogueEvent += PopUpHandler;
    }

    public void PopUp()
    {
        rectTransform.DOMoveY(0, 0.3f);
    }

    public void PopDown()
    {
        rectTransform.DOMoveY(-500, 0.3f);
    }

    private void PopUpHandler(bool value)
    {
        if (value == false)
        {
            PopDown();
        }
        else
        {
            PopUp();
        }
    }
}
