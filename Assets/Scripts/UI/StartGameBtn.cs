using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameBtn : MonoBehaviour
{
    public GameObject characterSelectBtn;

    public void OnClickedCharcterSelectBtn()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        UIManager.instance.SetGameObjectActive(characterSelectBtn, true);
    }
}
