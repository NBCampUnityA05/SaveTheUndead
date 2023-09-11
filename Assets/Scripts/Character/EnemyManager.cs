using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    public List<Enemy> EnemeisList { get; private set; }

    public GameObject player; // 임시 플레이어 참조용

    [SerializeField] private GameObject enemyPrefabs;

    bool[,] map = new bool[12,24];

    int emptySlot = 288;

    // 생성되는 칸을 한칸을 1f x 1f로 잡는다면?

    // 현재 가로줄 25f 길이, 세로줄은 12.5f 길이임

    // 그러면 배열을 bool[25][50] 으로 만듬

    // 만약 이번 Enemy의 pos이 x + 12.5f , y + 6.25f 의 인덱스에

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        EnemeisList = new List<Enemy>();

        for (int i =0; i< 12; i++)
        {
            for(int j=0; j <24; j++)
            {
                SpawnEnemy(i,j);
            }
            
        }
    }
    public void SpawnEnemy(int y, int x)
    {
        GameObject go = Instantiate(enemyPrefabs, new Vector3(-12.5f, -6.25f) + new Vector3(x * 1f, y * 1f), Quaternion.identity);
        Enemy enemyComponent = go.GetComponent<Enemy>();

        EnemeisList.Add(enemyComponent);
    }

    public Vector3 CheckEmptySpace(int x, int y)
    {
        
       while (emptySlot >0 && map[y, x])
        {
            x++;
            if (x >= map.GetLength(0))
            {
                x = 0;
                y++;
            }

            if (y >= map.GetLength(1))
            {
                y = 0;
            }
        }

        map[y, x] = true;
        emptySlot--;

        return new Vector3(-12.5f, -6.25f) + new Vector3(x * 1f, y * 1f);

    }

    public Vector3 SettingPos()
    {
        int x = UnityEngine.Random.Range(0, 25);
        int y = UnityEngine.Random.Range(0, 13);

        return CheckEmptySpace(x,y);
    }

}
