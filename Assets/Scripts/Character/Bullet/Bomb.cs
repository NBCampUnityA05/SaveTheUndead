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
                Invoke("BurstBomb", 2f);
            }
            else
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
        float rotZ = Random.Range(-20f, 20f);
        moveDirection = Quaternion.AngleAxis(rotZ, Vector3.up) * moveDirection * -1;
    }
}
