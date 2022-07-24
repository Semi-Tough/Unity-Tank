public class FailPanel : PanelRoot
{
    public CustomGUIButton BtnBack;
    public CustomGUIButton BtnAgain;


    private void OnEnable()
    {
        BtnBack.ClickEvent += BtnBackEvent;
        BtnAgain.ClickEvent += BtnAgainEvent;
    }

    #region GUIEvent

    private void BtnBackEvent()
    {
        StartSystem.Instance.InitStartScene();
    }

    private void BtnAgainEvent()
    {
        GameSystem.Instance.InitGameScene();
        GameSystem.Instance.GamePanel.EnemyHealthBar.SetActive(false);
    }

    #endregion

    private void OnDisable()
    {
        BtnBack.ClickEvent -= BtnBackEvent;
        BtnAgain.ClickEvent -= BtnAgainEvent;
    }
}