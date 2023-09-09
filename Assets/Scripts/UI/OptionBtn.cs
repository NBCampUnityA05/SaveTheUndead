using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionBtn;

    public void OnClickedOptionBtn()
    {
        optionBtn.SetActive(true);
    }
}
