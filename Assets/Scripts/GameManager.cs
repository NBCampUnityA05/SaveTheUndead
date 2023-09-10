using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // -----AudioTest 09.10 - ¹®Çö¿ì
        AudioManager.instance.PlayBgm(AudioManager.Bgm.MainScene);
        // -----
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
