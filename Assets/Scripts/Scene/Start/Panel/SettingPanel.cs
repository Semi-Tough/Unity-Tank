using UnityEngine.SceneManagement;

public class SettingPanel : PanelRoot
{
    public CustomGUISlider SliderBgMusic;
    public CustomGUISlider SliderEffectSound;
    public CustomGUIToggle ToggleBgMusic;
    public CustomGUIToggle ToggleEffectSound;
    public CustomGUIButton BtnClose;

    private MusicData musicData;

    private void OnEnable()
    {
        SliderBgMusic.ChangeValue += BgMusicSlider;
        SliderEffectSound.ChangeValue += EffectSoundSlider;
        ToggleBgMusic.ChangeValue += BgMusicToggle;
        ToggleEffectSound.ChangeValue += EffectSoundToggle;
        BtnClose.ClickEvent += CloseButton;
    }

    #region GUIEvent

    private void BgMusicSlider(float value)
    {
        musicData.BgMusicValue = value;
        AudioService.Instance.ChangeBgMusicVolume(value);
        ResourceService.Instance.SaveMusicData(musicData);
    }

    private void EffectSoundSlider(float value)
    {
        musicData.EffectSoundValue = value;
        ResourceService.Instance.SaveMusicData(musicData);
    }


    private void BgMusicToggle(bool isSel)
    {
        musicData.BgMusicState = isSel;
        AudioService.Instance.ChangeBgMusicState(isSel);
        ResourceService.Instance.SaveMusicData(musicData);
    }

    private void EffectSoundToggle(bool isSel)
    {
        musicData.EffectSoundState = isSel;
        ResourceService.Instance.SaveMusicData(musicData);
    }


    private void CloseButton()
    {
        HidePanel();
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            StartSystem.Instance.StartPanel.ShowPanel();
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            GameSystem.Instance.GamePanel.ShowPanel();
        }
    }

    #endregion

    private void OnDisable()
    {
        SliderBgMusic.ChangeValue -= BgMusicSlider;
        SliderEffectSound.ChangeValue -= EffectSoundSlider;
        ToggleBgMusic.ChangeValue -= BgMusicToggle;
        ToggleEffectSound.ChangeValue -= EffectSoundToggle;
        BtnClose.ClickEvent -= CloseButton;
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdateMusicData();
    }


    private void UpdateMusicData()
    {
        musicData = ResourceService.Instance.LoadMusicData();


        ToggleBgMusic.IsSel = musicData.BgMusicState;
        ToggleEffectSound.IsSel = musicData.EffectSoundState;

        SliderBgMusic.Value = musicData.BgMusicValue;
        SliderEffectSound.Value = musicData.EffectSoundValue;
    }
}