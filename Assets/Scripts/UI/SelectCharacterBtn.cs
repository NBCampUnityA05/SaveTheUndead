using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterBtn : MonoBehaviour
{
    public GameObject selectCharacterBtn;

    public void OnClickedCharcterSelectBtn()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        UIManager.instance.SetGameObjectActive(selectCharacterBtn, true);
    }
}
