using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    public List<Enemy> EnemeisList { get; private set; }

    public GameObject player; // 임시 플레이어 참조용

    [SerializeField] private GameObject enemyPrefabs;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        EnemeisList = new List<Enemy>();

        for (int i =0; i< 5; i++)
        {
            SpawnEnemy();
        }
    }
    public void SpawnEnemy()
    {
        GameObject go = Instantiate(enemyPrefabs, SettingPos(), Quaternion.identity);
        Enemy enemyComponent = go.GetComponent<Enemy>();

        EnemeisList.Add(enemyComponent);
    }

    public Vector3 SettingPos()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);

        return new Vector3(x, y);
    }

}
