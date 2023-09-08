using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameBtn : MonoBehaviour
{
    public GameObject characterSelectBG;

    public void OnClickedCharcterSelectBG()
    {
        characterSelectBG.SetActive(true);
    }
}
