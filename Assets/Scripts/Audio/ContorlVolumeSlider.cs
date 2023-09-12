using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContorlVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public Image volumeIcon;
    public Sprite[] volumeSprites;

    private void Start()
    {
        volumeSlider.value = AudioManager.instance.bgmVolume;
        // 슬라이더 값 변경 시 호출될 이벤트에 ChangeVolume 함수 연결
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        UpdateVolumeIcon(AudioManager.instance.bgmVolume);
    }

    public void ChangeVolume(float volume)
    {
        UpdateVolumeIcon(volume);
        AudioManager.instance.SetVolume(volume, volume);
    }

    private void UpdateVolumeIcon(float volume)
    {
        if (volume == 0)
        {
            volumeIcon.sprite = volumeSprites[0];
        }
        else if (volume <= 0.3f)
        {
            volumeIcon.sprite = volumeSprites[1];
        }
        else if(volume <= 0.7f)
        {
            volumeIcon.sprite = volumeSprites[2]; 
        }
        else
        {
            volumeIcon.sprite = volumeSprites[3];
        }
    }
}
