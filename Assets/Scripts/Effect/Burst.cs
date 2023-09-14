using UnityEngine;

public class Burst : MonoBehaviour
{
    float time = 1f;    
    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponentInParent<Bullet>();
        Player player = collision.GetComponentInParent<Player>();
        Enemy enemy = collision.GetComponentInParent<Enemy>();
        if (bullet != null)
        {
            bullet.TakeDamage();
        }
        else if (player != null)
        {
            player.TakeDamage();
        }
        else if(enemy != null)
        {
            enemy.TakeDamage();
        }
    }
  
}
