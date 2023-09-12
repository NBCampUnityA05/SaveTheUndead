using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public static BulletManager Instance { get; private set; }

    [SerializeField] private GameObject enemyBulletPrefabs;
    [SerializeField] private GameObject playerBulletPrefabs;
    [SerializeField] private GameObject potionPrefabs;
    [SerializeField] private GameObject bombPrefabs;

    public Camera mainCamera; // 임시 카메라 참조용

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShotEnemyBullet(Vector3 spawnPos, float speed)
    {
        if (Random.Range(0, 100) >= 97)
        {
            Instantiate(potionPrefabs, spawnPos, Quaternion.identity);
            return;
        }
        GameObject bullet = Instantiate(enemyBulletPrefabs, spawnPos, Quaternion.identity);
        bullet.GetComponent<Bullet>().speed = speed;
    }
}
