using System.Collections;
using UnityEngine;

public class GamePanel : PanelRoot
{
    public CustomGUILabel LabScoreNum;
    public CustomGUIButton BtnQuit;
    public CustomGUIButton BtnSetting;
    public CustomGUITexture TexPlayerHealthBar;

    public GameObject EnemyHealthBar;
    public CustomGUITexture TexEnemyHealthBar;
    public Transform TargetEnemy;
    public float CheckEnemyDistance;
    public float CheckEnemyInterval;

    private WaitForSeconds waitForSeconds;
    private Coroutine coroutine;
    private Transform player;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(CheckEnemyInterval);
    }

    private void OnEnable()
    {
        BtnQuit.ClickEvent += QuitButton;
        BtnSetting.ClickEvent += SettingButton;
        EnemyHealthBar.SetActive(false);
    }

    #region ClickEvent

    private void QuitButton()
    {
        GameSystem.Instance.QuitPanel.ShowPanel();
    }

    private void SettingButton()
    {
        StartSystem.Instance.SettingPanel.ShowPanel();
    }

    #endregion

    private void OnDisable()
    {
        BtnQuit.ClickEvent -= QuitButton;
        BtnSetting.ClickEvent -= SettingButton;
    }

    public void UpdateScore(int nowScore)
    {
        LabScoreNum.Content.text = nowScore.ToString();
    }

    public void UpdatePlayerHp(int hp, int maxHp)
    {
        if (hp > maxHp) hp = maxHp;
        TexPlayerHealthBar.CustomGUITransform.Width = (float) hp / maxHp * 450;
    }

    public void UpdateEnemyHp(int hp, int maxHp)
    {
        if (hp > maxHp) hp = maxHp;

        if (EnemyHealthBar.activeInHierarchy == false)
        {
            EnemyHealthBar.SetActive(true);
            coroutine = StartCoroutine(CheckEnemyDis());
        }

        TexEnemyHealthBar.CustomGUITransform.Width = (float) hp / maxHp * 450;
        if (hp > 0) return;
        EnemyHealthBar.SetActive(false);
        StopCoroutine(coroutine);
    }

    private IEnumerator CheckEnemyDis()
    {
        while (true)
        {
            yield return waitForSeconds;

            if (!player)
            {
                player = GameObject.FindWithTag("Player").transform;
            }

            if (TargetEnemy)
            {
                if (Vector3.Distance(TargetEnemy.position, player.position) > CheckEnemyDistance)
                {
                    EnemyHealthBar.SetActive(false);
                    StopCoroutine(coroutine);
                }
            }
            else
            {
                EnemyHealthBar.SetActive(false);
                StopCoroutine(coroutine);
            }
        }
        // ReSharper disable once IteratorNeverReturns
    }
}