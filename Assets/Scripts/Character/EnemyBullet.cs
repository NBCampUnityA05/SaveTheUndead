using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBullet : Bullet
{
    protected override void Start()
    {
        speed = Random.Range(0.5f, 2f);
        RotateBullet(EnemyManager.Instance.player.transform.position);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackCharacter();
            Debug.Log("Player Attacked!!!");
            GameManager.Instance.HitPlayer();
            //collision.gameObject.GetComponent<ICharacter>().TakeDamage();
        }
    }
}
