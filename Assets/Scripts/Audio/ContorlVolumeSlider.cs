using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContorlVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; // 슬라이더 컴포넌트
    public Image volumeIcon; // 볼륨 아이콘을 표시할 Image 컴포넌트
    public Sprite[] volumeSprites; // 볼륨 레벨에 따른 스프라이트 배열

    private void Start()
    {
        // AudioManager의 bgmVolume을 기준으로 슬라이더의 초기값 설정
        volumeSlider.value = AudioManager.instance.bgmVolume;

        // 슬라이더 값 변경 시 호출될 이벤트에 ChangeVolume 함수 연결
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        // 볼륨 아이콘 초기화
        UpdateVolumeIcon(AudioManager.instance.bgmVolume);
    }

    // 볼륨 값 변경 함수
    public void ChangeVolume(float volume)
    {
        // 볼륨 아이콘 업데이트
        UpdateVolumeIcon(volume);

        // AudioManager의 bgmVolume 및 sfxVolume 업데이트
        AudioManager.instance.SetVolume(volume, volume);
    }

    // 볼륨 아이콘 업데이트 함수
    private void UpdateVolumeIcon(float volume)
    {
        // 볼륨이 0 또는 매우 낮을 때
        if (volume == 0)
        {
            volumeIcon.sprite = volumeSprites[0]; // Element0 스프라이트 표시
        }
        // 볼륨이 중간일 때
        else if (volume <= 0.3f)
        {
            volumeIcon.sprite = volumeSprites[1]; // 중간 Element 스프라이트 표시
        }
        else if(volume <= 0.7f)
        {
            volumeIcon.sprite = volumeSprites[2]; 
        }
        // 볼륨이 최대일 때
        else
        {
            volumeIcon.sprite = volumeSprites[3]; // 최대 Element 스프라이트 표시
        }
    }
}
