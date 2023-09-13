using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private int selectedCharacterIndex = -1;
    public void ReceiveCharacterIndex(int characterIndex)
    {
        selectedCharacterIndex = characterIndex;
    }

    public void StartGame()
    {
        if (selectedCharacterIndex != -1)
        {
            PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacterIndex);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainScene");
        }
    }
}
