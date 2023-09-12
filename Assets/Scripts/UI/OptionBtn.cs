using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionBtn;

    public void OnClickedOptionBtn()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        optionBtn.SetActive(true);
    }
}
