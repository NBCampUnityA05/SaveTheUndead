using UnityEngine;

public class EnemyBullet : Bullet
{ 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponentInParent<Player>();
        if (player != null)
        {
            AttackCharacter();
            player.TakeDamage();
        }
    }
}
