using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour,ICharacter
{
    [SerializeField] protected Rigidbody2D rb2D;
    protected Vector3 moveDirection = Vector3.zero;
    protected float speed;

    protected virtual void Start()
    {
        speed = Random.Range(1.5f, 3f);
    }
    protected void FixedUpdate()
    {
        MoveBullet();
    }

    protected void Update()
    {
        CheckOutScreen();
    }

    protected void MoveBullet()
    {
        rb2D.velocity = moveDirection * speed ;
    }
    protected void CheckOutScreen()
    {
        Vector3 screenPos = BulletManager.Instance.mainCamera.WorldToViewportPoint(transform.position);

        if (screenPos.x > 1 || screenPos.x < 0 || screenPos.y > 1 || screenPos.y < 0)
        {
            Destroy(gameObject);
        }
    }
    public void AttackCharacter()
    {
        Destroy(gameObject);
    }
    public void TakeDamage()
    {
        Destroy(gameObject);
    }

    
}
