using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public enum AudioType
{
    BGM,SE,
    NextBGM,NextSE
}

[System.Serializable]
public class AudioVolume
{
    [SerializeField]
    public float BGMVolume = 1;
    [SerializeField]
    public float SEVolume = 1;
    [SerializeField]
    public bool BGMmute = true;
    [SerializeField]
    public bool SEmute = true;
}

public class AudioManager : SingletonMonoBehaviourBase<AudioManager>
{
    AudioSource BGMSource;
    AudioSource NextBGMSource;
    AudioSource SESource;
    AudioSource NextSESource;

    // JSONの内容を格納する変数
    AudioVolume volumes;

    private void Start()
    {
        SettingManager settingManager = SettingManager.Instance();
        settingManager.Load(SettingOriginator.AudioVolume);
        BGMSource = gameObject.AddComponent<AudioSource>();
        SESource = gameObject.AddComponent<AudioSource>();
        NextBGMSource = gameObject.AddComponent<AudioSource>();
        NextSESource = gameObject.AddComponent<AudioSource>();
        SetVolume();
    }

    public void SetVolume() { StartCoroutine(SetVolumes()); }

    IEnumerator SetVolumes()
    {
        yield return new WaitUntil(() => (BGMSource != null) ? true : false);
        BGMSource.volume = (volumes.BGMmute) ? volumes.BGMVolume : 0;
        BGMSource.loop = true;
        yield return new WaitUntil(() => (NextBGMSource != null) ? true : false);
        NextBGMSource.volume = (volumes.BGMmute) ? volumes.BGMVolume : 0;
        NextBGMSource.loop = true;
        yield return new WaitUntil(() => (SESource != null) ? true : false);
        SESource.volume = (volumes.SEmute) ? volumes.SEVolume : 0;
        SESource.loop = false;
        yield return new WaitUntil(() => (NextSESource != null) ? true : false);
        NextSESource.volume = (volumes.SEmute) ? volumes.SEVolume : 0;
        NextSESource.loop = false;
    }


    float time = 0;

        
    public void AudioFadeOut(float maxTime) { AudioFade(maxTime, FadeSpecified._1to0); }
    public void AudioFadeIn(float maxTime) { AudioFade(maxTime, FadeSpecified._0to1); }

    public void AudioFade(float maxTime, FadeSpecified fade)
    {
        Time_TimerManager time_TimerManager = Time_TimerManager.Instance();
        time_TimerManager.Fade(FadeVolumeWait, maxTime, fade);
    }

    void FadeVolumeWait(float fade)
    {
        BGMSource.volume = (volumes.BGMmute) ? volumes.BGMVolume * fade : 0;
    }


    public void SetLoad(AudioVolume sstVolume) { volumes = sstVolume; SetVolume(); }

    public AudioVolume GetVolume {  get { return volumes; } }

    public AudioClip SetBGM { set { BGMSource.clip = value; } }
    public AudioClip SetNextBGM { set { NextBGMSource.clip = value; } }
    public void PlayBGM(){ StartCoroutine(Check(AudioType.BGM)); }
    public AudioClip SetSE{ set { SESource.clip = value; } }
    public AudioClip SetNextSE{ set { NextSESource.clip = value; } }
    public void PlaySE() { StartCoroutine(Check(AudioType.SE)); }

    public void Play(AudioType type) { StartCoroutine(Check(type)); }

    IEnumerator Check(AudioType type)
    {
        yield return 0;

        switch (type)
        {
            case AudioType.BGM:
                if(BGMSource.clip == null)
                {
                    LoadFirst("firstBGM",type);
                    yield return new WaitUntil(() => (BGMSource.clip != null) ? true : false);
                }
                BGMSource.Play();
                break;
            case AudioType.SE:
                if (SESource.clip == null)
                {
                    LoadFirst("firstSE", type);
                    yield return new WaitUntil(() => (SESource.clip != null) ? true : false);
                }
                SESource.Play();
                break;
            case AudioType.NextBGM:
                break;
            case AudioType.NextSE:
                if (NextSESource.clip == null)
                {
                    LoadFirst("nextSE", type);
                    yield return new WaitUntil(() => (NextSESource.clip != null) ? true : false);
                }
                NextSESource.Play();
                break;
        }
    }



    private void LoadFirst(string name, AudioType type)
    {
        // Addressablesで非同期にアセットをロード
        AsyncOperationHandle<AudioClip> handle = Addressables.LoadAssetAsync<AudioClip>(name);

        // ロードが完了したときの処理
        handle.Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                switch (type)
                {
                    case AudioType.BGM:
                        SetBGM = op.Result;
                        break;
                    case AudioType.SE:
                        SetSE = op.Result;
                        break;
                    case AudioType.NextBGM:
                        SetNextBGM = op.Result;
                        break;
                    case AudioType.NextSE:
                        SetNextSE = op.Result;
                        break;
                }
            }
            else
            {
                Debug.LogError("AudioClipのロードに失敗しました");
            }
        };
    }
}
