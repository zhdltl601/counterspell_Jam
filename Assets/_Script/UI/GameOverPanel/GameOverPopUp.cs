using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameOverPopUp : MonoBehaviour, IPopUpable
{
    private CanvasGroup _gameOverPanelGroup;

    private void Awake()
    {
        _gameOverPanelGroup = GetComponent<CanvasGroup>();
    }

    public void PopUp()
    {
        _gameOverPanelGroup.DOFade(1, 0.3f);
    }

    public void PopDown()
    {
        _gameOverPanelGroup.DOFade(0, 0f);
    }
}
