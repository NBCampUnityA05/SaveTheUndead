using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    float remainCoolTime = 0f;
    float COOL_TIME = 4.5f;
    Vector3 moveDirection = Vector3.right;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer left;
    [SerializeField] private SpriteRenderer right;
    [SerializeField] private Transform spawnBullet;

    Vector3 leftPos = Vector3.zero;
    Vector3 rightPos = Vector3.zero;
    bool isFlip = false;

    private void Start()
    {
        leftPos = left.transform.position;
        rightPos = right.transform.position;
    }

    private void Update()
    {
        remainCoolTime -= Time.deltaTime;
        if (remainCoolTime <= 0f) AttackCharacter();
    }

    private void FixedUpdate()
    {
        RotateEnemyToPlayer();
    }

    public void AttackCharacter()
    {
        int rate = Random.Range(0, 100);
        BulletType type;
        float speed;
        if (rate >= 98)
        {
            type = BulletType.Bomb;
            speed = Random.Range(3.5f, 4.5f);
        }
        else if(rate >= 95)
        {
            type = BulletType.Potion;
            speed = Random.Range(3.5f, 4.5f);
        }
        else
        {
            type = BulletType.Enemy;
            speed = Random.Range(0.5f, 2f);
        }

        BulletManager.Instance.ShotBullet(type, spawnBullet.position, speed);
        remainCoolTime = COOL_TIME;
    }

    private void RotateEnemyToPlayer()
    {
        moveDirection = (PlayerManager.Instance.player.transform.position - transform.position).normalized;
        float rotZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        FlipXEnemy(Mathf.Abs(rotZ) > 90);
    }    

    private void FlipXEnemy(bool result)
    {
        if (isFlip != result)
        {
            body.flipX = result;
            left.flipX = result;
            right.flipX = result;

            if (result == true)
            {    
                left.transform.position = rightPos;
                right.transform.position = leftPos;
                right.transform.rotation = Quaternion.Euler(0, 0, 45f);
                isFlip = true;
            }
            else
            {
                left.transform.position = leftPos;
                right.transform.position = rightPos;
                right.transform.rotation = Quaternion.Euler(0, 0, -45f);
                isFlip = false;
            }
            
        }
        
    }

    public void TakeDamage() 
    {
        EnemyManager.Instance.Enemies.Remove(this);
        Destroy(gameObject);
    }
}
