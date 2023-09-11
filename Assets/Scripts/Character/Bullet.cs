using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,ICharacter
{
    [SerializeField] private Rigidbody2D rb2D;
    Vector3 moveDirection = Vector3.right;
    float speed;

    // 플레이어의 방향을 받아서 해당 방향으로 계속해서 움직이다가 화면 밖으로 나갈때 사라진다.

    private void Start()
    {
        //moveDirection =  (GameManager.Instance.player.transform.position -transform.position).normalized;
        RotateBulletToPlayer();
        speed = 5f;
    }


    private void FixedUpdate()
    {
        MoveBullet();
    }
    private void RotateBulletToPlayer()
    {
        // 플레이어 방향으로 회전
        float rotZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        // 해당 방향으로의 각도를 구한다.

        transform.rotation = Quaternion.Euler(0, 0, rotZ);    
    }

    private void MoveBullet()
    {
        rb2D.velocity = moveDirection * speed ;
    }

    public void AttackCharacter()
    {
        // 플레이어와 부딫혔을때 실행될 메서드
    }

    public void TakeDamage()
    {
        // 벽에 부딫혔을때?
    }

    
}
