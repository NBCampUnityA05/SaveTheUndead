using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bomb : Bullet
{
    [SerializeField] private GameObject burstPrefabs;

    protected override void Start()
    {
        speed = 5f;
        RotateBullet(EnemyManager.Instance.player.transform.position);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackCharacter();
            // 1. 플레이어가 적(농부)들이 던진 폭탄을 공격으로 받아친다.
            // 1-1. 폭탄이 터지면서 날아가서 지나가는 범위의 총알을 지워준다.
            // 1-2. 받아친 폭탄은 적(농부) 부딪히면 폭발하여 농부를 처치한다.
            // 1-3. 둘다

            // 2. 플레이어가 폭탄을 먹으면 폭탄을 사용할 수 있다 ( 소모성)
            // 2-1. 폭탄을 사용하면 근처 총알이 사라진다.
            // 2-2. 폭탄을 사용하면 근처 농부가 사라진다.
            // 2-3. 둘다
        }
    }

    public void BurstBomb()
    {
        Instantiate(burstPrefabs,transform.position, Quaternion.identity);
        Destroy(this);
    }
}
