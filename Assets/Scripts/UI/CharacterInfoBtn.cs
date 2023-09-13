using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoBtn : MonoBehaviour
{
    public GameObject[] characterInfos;

    public void OnClickedCharacterInfoBtn(int characterIndex)
    {
        DeactivateAllCharacterInfos();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        StartScene startScene = FindObjectOfType<StartScene>();
        if (startScene != null)
        {
            startScene.ReceiveCharacterIndex(characterIndex);
        }
        UIManager.instance.SetGameObjectActive(characterInfos[characterIndex], true);
    }

    void DeactivateAllCharacterInfos()
    {
        foreach (GameObject characterInfo in characterInfos)
        {
            UIManager.instance.SetGameObjectActive(characterInfo, false);
        }
    }
}
