using UnityEngine;

public class StartPanel : PanelRoot
{
    public CustomGUIButton BtnStart;
    public CustomGUIButton BtnQuit;
    public CustomGUIButton BtnSetting;
    public CustomGUIButton BtnTop;

    private void OnEnable()
    {
        BtnStart.ClickEvent += StartButton;
        BtnQuit.ClickEvent += QuitButton;
        BtnSetting.ClickEvent += SettingButton;
        BtnTop.ClickEvent += TopButton;
    }

    #region ClickEvent

    private void StartButton()
    {
        GameSystem.Instance.InitGameScene();
    }

    private void QuitButton()
    {
        Application.Quit();
    }

    private void SettingButton()
    {
        StartSystem.Instance.SettingPanel.ShowPanel();
        HidePanel();
    }

    private void TopButton()
    {
        StartSystem.Instance.TopPanel.ShowPanel();
        HidePanel();
    }

    #endregion

    private void OnDisable()
    {
        BtnStart.ClickEvent -= StartButton;
        BtnQuit.ClickEvent -= QuitButton;
        BtnSetting.ClickEvent -= SettingButton;
        BtnTop.ClickEvent -= TopButton;
    }
}