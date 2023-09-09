using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnBtn : MonoBehaviour
{
    public GameObject returnBtn;

    public void OnClickedReturnBtn()
    {
        returnBtn.SetActive(false);
    }
}
