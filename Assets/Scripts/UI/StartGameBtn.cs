using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameBtn : MonoBehaviour
{
    public void OnClickedStartGameBtn()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        UIManager.instance.LoadScene("MainScene");
    }
}
