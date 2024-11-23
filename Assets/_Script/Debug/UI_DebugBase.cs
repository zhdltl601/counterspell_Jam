using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class UI_DebugBase<T> : MonoSingleton<T> where T : UI_DebugBase<T>
{
    private const bool disableALLUI = false;
    [SerializeField] private bool active = true && !disableALLUI;
    [SerializeField] private List<TextMeshProUGUI> list;
    public IList<TextMeshProUGUI> GetList => list;
    private void Start()
    {
        gameObject.SetActive(active);
    }
}

