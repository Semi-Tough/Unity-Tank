using UnityEngine;

public class AudioService : ServiceRoot<AudioService>
{
    public AudioSource BgSource;

    public void PlayBgMusic(string path, bool loop = true)
    {
        MusicData musicData = ResourceService.Instance.LoadMusicData();
        AudioClip audioClip = ResourceService.Instance.LoadAudioClip(path);

        BgSource.mute = !musicData.BgMusicState;
        BgSource.volume = musicData.BgMusicValue / 100;

        if (BgSource.clip != audioClip) BgSource.clip = audioClip;

        BgSource.loop = true;
        BgSource.Play();
    }

    public void PlayEffectSound(AudioSource audioSource)
    {
        MusicData musicData = ResourceService.Instance.LoadMusicData();
        audioSource.mute = !musicData.EffectSoundState;
        audioSource.volume = musicData.EffectSoundValue / 100;
        audioSource.Play();
    }

    public void ChangeBgMusicVolume(float value)
    {
        BgSource.volume = value / 100;
    }

    public void ChangeBgMusicState(bool open)
    {
        BgSource.mute = !open;
    }
}