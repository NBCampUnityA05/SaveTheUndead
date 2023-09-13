using UnityEngine;

public class Bomb : Bullet
{
    [SerializeField] private GameObject burstPrefabs;

    public void OnTriggerEnter2D(Collider2D collision)
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
                AttackCharacter();
                BurstBomb();
            }
        }
    }

    public void BurstBomb()
    {
        Instantiate(burstPrefabs,transform.position, Quaternion.identity);
        Destroy(this);
    }

    public void HitBomb()
    {
        moveDirection = -moveDirection;
    }
}
