using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{   
    float remainCoolTime = 0f;
    float COOL_TIME = 3f;

    private void Update()
    {
        remainCoolTime -= Time.deltaTime;
        if (remainCoolTime <= 0f) AttackCharacter();
    }

    

    public void AttackCharacter()
    {
        RotateEnemyToPlayer();
        BulletManager.Instance.ShotBullet(transform.position);
        remainCoolTime = COOL_TIME;
    }

    private void RotateEnemyToPlayer()
    {
        // 플레이어 방향으로 회전?
    }

    public void TakeDamage() {}

    // Player의 위치를 받아서 방향을 Player 방향으로 변경한다.
}
