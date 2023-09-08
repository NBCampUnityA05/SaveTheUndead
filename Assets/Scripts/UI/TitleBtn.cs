using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBtn : MonoBehaviour
{
    public GameObject CharacterSelectBG;

    public void OnClickedTitleBtn()
    {
        CharacterSelectBG.SetActive(false);
    }
}
