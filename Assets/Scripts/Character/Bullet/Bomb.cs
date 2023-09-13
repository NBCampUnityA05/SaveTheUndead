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
                HitBomb();
                
                /*AttackCharacter();
                BurstBomb();*/
                // 폭탄을 쳐내지 못하고 터져버림
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
