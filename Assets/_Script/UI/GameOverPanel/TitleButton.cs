using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    private Button _titleButton;

    private void Awake()
    {
        _titleButton = GetComponent<Button>();
    }

    private void Start()
    {
        _titleButton.onClick.AddListener(HandleResetTitleEvent);
    }

    private void HandleResetTitleEvent()
    {
        UIManager.Instance.ResetTitle();
    }
}
