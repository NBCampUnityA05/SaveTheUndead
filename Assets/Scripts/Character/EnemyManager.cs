using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    public List<Enemy> EnemeisList { get; private set; }

    private void Awake()
    {
        if(Instance == null) Instance = this;   
    }

    // 맵에서 빈자리를 찾아서 enemy를 생성한다.

    // Enemy를 List로 관리하면서 Enemy들이 플레이어를 추적하도록 한다.

    // Enemy들이 각자의 쿨타임마다 총을 발사한다.

}
