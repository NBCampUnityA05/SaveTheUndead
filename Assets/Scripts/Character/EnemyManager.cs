using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    public GameObject player; // 임시 플레이어 참조용

    [SerializeField] private GameObject enemyPrefabs;

    List<List<int[]>> mapList = new List<List<int[]>>();

    private void Awake()
    {
        if(Instance == null) Instance = this;
        mapList = new List<List<int[]>>();
        InitMap();
    }

    public void InitMap()
    {
        int width = 24;
        int height = 12;

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
        GameObject go = Instantiate(enemyPrefabs, FindEmptyPos(), Quaternion.identity);
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

        return new Vector3(-12.5f, -6.25f) + new Vector3(pos[1] * 1f, pos[0] * 1f);

    }

}
