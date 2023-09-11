using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, ICharacter
{
    float remainCoolTime = 0f;
    float COOL_TIME = 3f;
    Vector3 moveDirection = Vector3.right;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer left;
    [SerializeField] private SpriteRenderer right;

    private void Start()
    {
    
    }

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
        moveDirection = (EnemyManager.Instance.player.transform.position - transform.position).normalized; // 임시로 EnemyManager 참조
        float rotZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        FlipXEnemy(Mathf.Abs(rotZ) > 90);
    }    

    private void FlipXEnemy(bool result)
    {
        body.flipX = result;
        left.flipX = result;
        right.flipX = result;
    }

    public void TakeDamage() {}

    // Player의 위치를 받아서 방향을 Player 방향으로 변경한다.
}
