using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public static BulletManager Instance { get; private set; }
    public List<Bullet> BulletsList { get; private set; }

    [SerializeField] private GameObject bulletPrefabs;
    
    public Camera mainCamera; // 임시 카메라 참조용

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        BulletsList = new List<Bullet>();
    }

    private void Update()
    {
       
    }

    public void ShotBullet(Vector3 spawnPos)
    {
        GameObject go = Instantiate(bulletPrefabs, spawnPos, Quaternion.identity);
        Bullet bullet = go.GetComponent<Bullet>();
        BulletsList.Add(bullet);
    }

    public void DestroyBullet(Bullet bullet)
    {
        BulletsList.Remove(bullet);
        Destroy(bullet.gameObject);
    }
}
