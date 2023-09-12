using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Bullet
{
    protected override void Start()
    {
        RotateBullet(EnemyManager.Instance.player.transform.position);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackCharacter();
            GameManager.Instance.TakePotion();
            //collision.gameObject.GetComponent<ICharacter>().TakeDamage();
        }
    }

}
