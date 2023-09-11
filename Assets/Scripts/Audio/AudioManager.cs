using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip[] bgmClip;
    public float bgmVolume;
    public int bgmChannels;
    AudioSource[] bgmPlayers;
    int bgmChannelIndex;

    [Header("#SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public int sfxChannels;
    AudioSource[] sfxPlayers;
    int sfxChannelIndex;

    void Awake()
    {
        instance = this;
        Init();
        // MainScene으로 넘어가도 파괴되지 않게 설정.
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        PlayBgm(Bgm.StartScene);
    }

    public enum Bgm { StartScene, MainScene }
    public enum Sfx { Dead, Hit, LevelUp=3, Lose, Melee, Range=7, Select, Win}

    void Init()
    {
        // 배경음 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayers = new AudioSource[bgmChannels];

        for(int bgmIndex = 0; bgmIndex < bgmPlayers.Length; bgmIndex++)
        {
            bgmPlayers[bgmIndex] = bgmObject.AddComponent<AudioSource>();
            bgmPlayers[bgmIndex].playOnAwake = false;
            bgmPlayers[bgmIndex].volume = bgmVolume;
        }

        // 효과음 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[sfxChannels];

        for(int sfxIndex = 0;  sfxIndex < sfxPlayers.Length; sfxIndex++)
        {
            sfxPlayers[sfxIndex] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[sfxIndex].playOnAwake = false;
            sfxPlayers[sfxIndex].volume = sfxVolume;
        }
    }

    public void SetVolume(float bgmVolume, float sfxVolume)
    {
        this.bgmVolume = bgmVolume;
        this.sfxVolume = sfxVolume;

        // 모든 BGM 및 SFX 오디오 소스의 볼륨 설정
        foreach (var bgmPlayer in bgmPlayers)
        {
            bgmPlayer.volume = bgmVolume;
        }

        foreach (var sfxPlayer in sfxPlayers)
        {
            sfxPlayer.volume = sfxVolume;
        }
    }

    public void PlayBgm(Bgm bgm)
    {
        // 이전 BGM 중지
        for (int index = 0; index < bgmPlayers.Length; index++)
        {
            if (bgmPlayers[index].isPlaying)
            {
                bgmPlayers[index].Stop();
            }
        }

        // 새로운 BGM 재생
        for (int index = 0; index < bgmPlayers.Length; index++)
        {
            int loopIndex = (index + bgmChannelIndex) % bgmPlayers.Length;

            if (!bgmPlayers[loopIndex].isPlaying)
            {
                bgmChannelIndex = loopIndex;
                bgmPlayers[loopIndex].clip = bgmClip[(int)bgm];
                bgmPlayers[loopIndex].loop = true; // BGM 루프 재생 설정
                bgmPlayers[loopIndex].Play();
                break;
            }
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for(int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + sfxChannelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            sfxChannelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
