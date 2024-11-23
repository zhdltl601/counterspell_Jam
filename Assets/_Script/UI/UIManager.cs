using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MonoSingletonUsage(MonoSingletonFlags.DontDestroyOnLoad)]
public class UIManager : MonoSingleton<UIManager>
{
    public TitleUI titleUI;

    public void ResetTitle()
    {
        titleUI.ResetUIPosition();
        PopUpManager.Instance.UnloadAllPopUps();
    }
}
