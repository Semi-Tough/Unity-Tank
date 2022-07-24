using System.Collections.Generic;
using UnityEngine;

public class ResourceService : ServiceRoot<ResourceService>
{
    public MusicData LoadMusicData()
    {
        MusicData musicData = PlayerPrefsManager.Instance.LoadData("Music", typeof(MusicData)) as MusicData;

        if (musicData is not {NotFirst: false}) return musicData;
        musicData.BgMusicState = true;
        musicData.EffectSoundState = true;
        musicData.BgMusicValue = 100;
        musicData.EffectSoundValue = 100;
        musicData.NotFirst = true;
        PlayerPrefsManager.Instance.SaveData("Music", musicData);
        return musicData;
    }

    public void SaveMusicData(MusicData musicData)
    {
        PlayerPrefsManager.Instance.SaveData("Music", musicData);
    }
    
    public TopListData LoadTopListData()
    {
        TopListData topListData = PlayerPrefsManager.Instance.LoadData("TopList", typeof(TopListData)) as TopListData;
        return topListData;
    }

    private void SaveTopListData(TopListData topListData)
    {
        PlayerPrefsManager.Instance.SaveData("TopList", topListData);
    }


    public void UpdateTopData(TopData topData)
    {
        TopListData topListData = LoadTopListData();

        topListData.List.Add(topData);
        topListData.List.Sort(((data1, data2) => data1.Score > data2.Score ? -1 : 1));

        if (topListData.List.Count > 3)
        {
            topListData.List.Remove(topListData.List[^1]);
        }

        Instance.SaveTopListData(topListData);
    }


    private readonly Dictionary<string, AudioClip> audioDictionary
        = new Dictionary<string, AudioClip>();

    public AudioClip LoadAudioClip(string path, bool cache = true)
    {
        if (audioDictionary.TryGetValue(path, out AudioClip audioClip)) return audioClip;
        audioClip = Resources.Load<AudioClip>(path);
        if (cache) audioDictionary.Add(path, audioClip);
        return audioClip;
    }
}