using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopUp : MonoBehaviour, IPopUpable
{
    private CanvasGroup _gameOverPanelGroup;
    [SerializeField] private Image backGround;
    
    private void Awake()
    {
        _gameOverPanelGroup = GetComponent<CanvasGroup>();
    }

    public void PopUp()
    {
        backGround.DOFade(0.7f , 0.7f).OnComplete(() =>
        {
            _gameOverPanelGroup.DOFade(1, 0.3f);
        });
    }

    public void PopDown()
    {
        _gameOverPanelGroup.DOFade(0, 0f);
    }
}
