using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : SystemRoot<GameSystem>
{
    public GamePanel GamePanel;
    public QuitPanel QuitPanel;
    public VictoryPanel VictoryPanel;
    public FailPanel FailPanel;

    public int NowScore { private set; get; }
    public bool Gaming;

    public void InitGameScene()
    {
        SceneManager.LoadScene("GameScene");
        StartSystem.Instance.StartPanel.HidePanel();
        StartSystem.Instance.SettingPanel.HidePanel();
        StartSystem.Instance.TopPanel.HidePanel();
        QuitPanel.HidePanel();
        VictoryPanel.HidePanel();
        FailPanel.HidePanel();
        GamePanel.ShowPanel();
        NowScore = 0;
        GamePanel.UpdateScore(NowScore);
        GamePanel.UpdatePlayerHp(100, 100);
        AudioService.Instance.PlayBgMusic(Constants.GameBgSceneBgMusic);
        PoolService.Instance.RecoveryAll();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (Gaming) PauseGame();
        else ContinueGame();
    }

    public void PauseGame()
    {
        Gaming = false;
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ContinueGame()
    {
        Gaming = true;
        Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateScore(int value)
    {
        NowScore += value;
        GamePanel.UpdateScore(NowScore);
    }
}