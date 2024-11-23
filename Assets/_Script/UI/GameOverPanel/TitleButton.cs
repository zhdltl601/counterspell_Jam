using UnityEngine.UI;

public class TitleButton : HoverButton
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
        print("dajidwaioajodjoa ");
        UIManager.Instance.ResetTitle();
    }
}
