using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    public List<Enemy> Enemies { get; private set; }

    public GameObject player; // 임시 플레이어 참조용

    [SerializeField] private GameObject[] enemyArray = new GameObject[4];
    List<List<int[]>> mapList = new List<List<int[]>>();

    // 맵크기와 맵분할 관련 상수
    float startX = -17.5f;
    float startY = -9f;
    float spacing = 1f;
    int width = 36;
    int height = 19;


    private void Awake()
    {
        if(Instance == null) Instance = this;
        Enemies = new List<Enemy>();
        mapList = new List<List<int[]>>();
        InitMap();
    }

    private void Start()
    {
        for (int i =0; i< 36; i++)
        {
            SpawnEnemy();
        }
    }
    public void InitMap()
    {
        for (int i = 0; i < 3; i++)
        {
            List<int[]> temp = new List<int[]>();

            for (int j = i; j < height - i; j++)
            {
                temp.Add(new int[] { j, i });
                temp.Add(new int[] { j, width - 1 - i });
            }

            for (int j = i + 1; j < width - (i + 1); j++)
            {
                temp.Add(new int[] { i, j });
                temp.Add(new int[] { height - 1 - i, j });
            }

            mapList.Add(temp);
        }
    }
    public void SpawnEnemy()
    {
        if (mapList.Count == 0) 
        {
            Debug.Log("Enemy를 더이상 Spawn시킬 자리가 없습니다");
            return;
        }
        
        GameObject go = Instantiate(enemyArray[UnityEngine.Random.Range(0,4)], FindEmptyPos(), Quaternion.identity);
        Enemies.Add(go.GetComponent<Enemy>());
    }
    public Vector3 FindEmptyPos()
    {
        int index = UnityEngine.Random.Range(0, mapList[0].Count);

        int[] pos = mapList[0][index];

        mapList[0].RemoveAt(index);


        if(mapList[0].Count == 0)
        {
            mapList.RemoveAt(0);
        }

        return new Vector3(startX, startY) + new Vector3(pos[1] * spacing, pos[0] * spacing);

    }

}
