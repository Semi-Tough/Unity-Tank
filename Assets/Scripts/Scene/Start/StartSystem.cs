using UnityEngine.SceneManagement;

public class StartSystem : SystemRoot<StartSystem>
{
    public StartPanel StartPanel;
    public SettingPanel SettingPanel;
    public TopPanel TopPanel;


    public void InitStartScene()
    {
        SceneManager.LoadScene("StartScene");
        GameSystem.Instance.GamePanel.HidePanel();
        GameSystem.Instance.QuitPanel.HidePanel();
        GameSystem.Instance.VictoryPanel.HidePanel();
        GameSystem.Instance.FailPanel.HidePanel();
        SettingPanel.HidePanel();
        TopPanel.HidePanel();
        StartPanel.ShowPanel();
        AudioService.Instance.PlayBgMusic(Constants.StartBgSceneBgMusic);
        PoolService.Instance.RecoveryAll();
    }
}