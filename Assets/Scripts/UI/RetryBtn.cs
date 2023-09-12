using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryBtn : MonoBehaviour
{
    public GameObject retryBtn;
    public void RetryGame()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        GameManager.Instance.StartGame();
        Time.timeScale = 1f;
        UIManager.instance.LoadScene("MainScene");
    }
}
