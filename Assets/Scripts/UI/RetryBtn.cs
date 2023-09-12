using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryBtn : MonoBehaviour
{
    public GameObject retryBtn;
    public void RetryGame()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        UIManager.instance.LoadScene("MainScene");
    }
}
