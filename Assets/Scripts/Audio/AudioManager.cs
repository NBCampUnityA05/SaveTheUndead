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
    
    public void PlayBgm(Bgm bgm)
    {
        for(int index = 0; index < bgmPlayers.Length; index++)
        {
            int loopIndex = (index + bgmChannelIndex) % bgmPlayers.Length;

            if (bgmPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            bgmChannelIndex = loopIndex;
            bgmPlayers[loopIndex].clip = bgmClip[(int)bgm];
            bgmPlayers[loopIndex].Play();
            break;
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
