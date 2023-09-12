using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public static BulletManager Instance { get; private set; }

    [SerializeField] private GameObject enemyBulletPrefabs;
    [SerializeField] private GameObject playerBulletPrefabs;
    [SerializeField] private GameObject potionPrefabs;

    public Camera mainCamera; // 임시 카메라 참조용

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShotEnemyBullet(Vector3 spawnPos)
    {
        if (Random.Range(0, 100) >= 97)
        {
            Instantiate(potionPrefabs, spawnPos, Quaternion.identity);
            return;
        }
        Instantiate(enemyBulletPrefabs, spawnPos, Quaternion.identity);
    }
}
