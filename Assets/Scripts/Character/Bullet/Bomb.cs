using UnityEngine;

public class Bomb : Bullet
{
    [SerializeField] private GameObject burstPrefabs;
    bool isHit = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit)
        {
            Player player = collision.GetComponentInParent<Player>();
            if (player != null)
            {
                if (player.IsAttack)
                {
                    HitBomb();
                }
                else
                {
                    BurstBomb();
                }
            }
        }
        else
        {
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                BurstBomb();
            }
        }
        
    }

    public void BurstBomb()
    {
        AttackCharacter();
        Instantiate(burstPrefabs,transform.position, Quaternion.identity);
        
    }

    public void HitBomb()
    {
        isHit = true;
        float rotZ = Random.Range(-20f, 20f);
        moveDirection = Quaternion.AngleAxis(rotZ, Vector3.up) * moveDirection * -1;
        speed += 1f;
    }
}
