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
        SceneManager.LoadScene("MainScene");
   }
}
