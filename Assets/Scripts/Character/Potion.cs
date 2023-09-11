using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Bullet
{
    protected override void Start()
    {
        speed = 10f;
        RotateBullet(EnemyManager.Instance.player.transform.position);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackCharacter();
            //collision.gameObject.GetComponent<ICharacter>().TakeDamage();
        }
    }

}
