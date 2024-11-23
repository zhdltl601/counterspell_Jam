using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _titleCanvasGroup;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private float _buttonOffsetPosition;
    private float _buttonOriginLocalPositionX;

    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(0.4f);

    private void Start()
    {
        _buttonOriginLocalPositionX = _buttons[0].GetComponent<RectTransform>().localPosition.x;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameStartButtonClicked();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetUIPosition();
        }
    }

    public void GameStartButtonClicked()
    {
        StartCoroutine(nameof(GameStart));
    }
    
    private IEnumerator GameStart()
    {
        _titleCanvasGroup.interactable = false;
        _titleText.DOFade(0, 0.3f);
        
        foreach (var button in _buttons)
        {
            button.transform.DOMoveX(_buttonOriginLocalPositionX + _buttonOffsetPosition, 0.3f);
            yield return _waitForSeconds;
        }
    }

    public void ResetUIPosition()
    {
        _titleCanvasGroup.interactable = true;
        _titleText.DOFade(1, 0.3f);
        foreach (var button in _buttons)
        {
            button.transform.DOMoveX(_buttonOriginLocalPositionX, 0.3f);
        }
    }
}
