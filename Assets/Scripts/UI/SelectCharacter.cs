using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public GameObject character;

    // CharacterIndex -> MainScene
    // AddListener 사용 예정. 추후 변경 가능
    public void OnclickedCharacter()
    {
        if (character != null)
        {
            // character 객체가 null이 아닐 때만 아래 코드 실행
            UIManager.instance.LoadScene("MainScene");
        }
        else
        {
            Debug.LogError("character 객체가 할당되지 않았습니다.");
        }
    }
}
