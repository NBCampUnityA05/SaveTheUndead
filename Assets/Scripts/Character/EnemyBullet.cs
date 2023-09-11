using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBullet : Bullet
{
    protected override void Start()
    {
        base.Start();
        RotateBulletToPlayer();
    }

    private void RotateBulletToPlayer()
    {
        moveDirection = (EnemyManager.Instance.player.transform.position - transform.position).normalized; // 임시로 EnemyManager 참조

        float rotZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + Random.Range(-80f, 80f);
        moveDirection = Quaternion.AngleAxis(rotZ, Vector3.up) * moveDirection;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackCharacter();
            //collision.gameObject.GetComponent<ICharacter>().TakeDamage();
        }
    }
}
