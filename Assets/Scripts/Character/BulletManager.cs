using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Enemy,
    Player,
    Potion,
    Bomb,
}

public class BulletManager : MonoBehaviour
{

    public static BulletManager Instance { get; private set; }

    [SerializeField] private GameObject[] prefabs = new GameObject[4];

    public Camera mainCamera; // 임시 카메라 참조용

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShotBullet(BulletType type, Vector3 spawnPos, float speed)
    {
        GameObject bullet = Instantiate(prefabs[(int)type], spawnPos, Quaternion.identity);
        bullet.GetComponent<Bullet>().speed = speed;
    }
}
