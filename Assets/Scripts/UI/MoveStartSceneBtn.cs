using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStartSceneBtn : MonoBehaviour
{
    public void OnClickedMoveStartSceneBtn()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        AudioManager.instance.PlayBgm(false);
        UIManager.instance.LoadScene("StartScene");
        GameManager.Instance.RetryGame();
    }
}
