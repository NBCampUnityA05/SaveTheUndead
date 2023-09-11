using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public static BulletManager Instance { get; private set; }
    public List<Bullet> BulletsList { get; private set; }

    [SerializeField] private GameObject bulletPrefabs;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
       
    }

    public void ShotBullet(Vector3 spawnPos)
    {
        Instantiate(bulletPrefabs, spawnPos, Quaternion.identity);
    }
}
