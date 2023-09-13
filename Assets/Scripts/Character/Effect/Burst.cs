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
    private void OnTriggerStay2D(Collider2D collision)
    {
        Bullet isbullet = collision.GetComponentInParent<Bullet>();
        if (isbullet != null)
        {
            isbullet.TakeDamage();
        }
    }
  
}
