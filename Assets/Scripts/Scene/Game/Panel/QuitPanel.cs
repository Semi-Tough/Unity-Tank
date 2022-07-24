public class QuitPanel : PanelRoot
{
    public CustomGUIButton BtnClose;
    public CustomGUIButton BtnContinue;
    public CustomGUIButton BtnQuit;

    private void OnEnable()
    {
        BtnClose.ClickEvent += CloseButton;
        BtnContinue.ClickEvent += ContinueButton;
        BtnQuit.ClickEvent += QuitButton;
    }

    #region ButtonEvent

    private void ContinueButton()
    {
        HidePanel();
        GameSystem.Instance.ContinueGame();
    }

    private void CloseButton()
    {
        HidePanel();
    }

    private void QuitButton()
    {
        StartSystem.Instance.InitStartScene();
    }

    #endregion

    private void OnDisable()
    {
        BtnClose.ClickEvent -= CloseButton;
        BtnContinue.ClickEvent -= ContinueButton;
        BtnQuit.ClickEvent -= QuitButton;
    }
}