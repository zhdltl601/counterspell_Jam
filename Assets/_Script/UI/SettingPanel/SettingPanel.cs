using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour, IPopUpable
{
    [SerializeField] private CanvasGroup _settingPanel;
    
    public void PopUp()
    {
        _settingPanel.alpha = 1;
        _settingPanel.interactable = true;
    }

    public void PopDown()
    {
        _settingPanel.alpha = 0;
        _settingPanel.interactable = false;
    }
}
