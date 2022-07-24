using System;
using System.Globalization;

public class VictoryPanel : PanelRoot
{
    public CustomGUIInput InputInfo;
    public CustomGUIButton BtnSure;

    private void OnEnable()
    {
        BtnSure.ClickEvent += BtnSureEvent;
    }

    #region GUIEvent

    private void BtnSureEvent()
    {
        ResourceService.Instance.UpdateTopData(new TopData(InputInfo.Content.text,
            GameSystem.Instance.NowScore, DateTime.Now.ToString(CultureInfo.CurrentCulture)));

        StartSystem.Instance.InitStartScene();
    }

    #endregion

    private void OnDisable()
    {
        BtnSure.ClickEvent -= BtnSureEvent;
    }
}