using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowModeDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(HandleWindowModeChanged);
    }

    private void HandleWindowModeChanged(int optionIdx)
    {
        switch (optionIdx)
        {
            case 1:
                Screen.SetResolution(Screen.width, Screen.height, true);
                break;
            case 2:
                Screen.SetResolution(Screen.width, Screen.height, false);
                break;
            default:
                break;
        }
    }
}
