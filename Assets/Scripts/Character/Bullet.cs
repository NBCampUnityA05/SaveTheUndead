using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour,ICharacter
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    Vector3 moveDirection = Vector3.zero;
    float speed;

    private void Start()
    {
        speed = Random.Range(1.5f, 3f);
        RotateBulletToPlayer();
    }
    private void FixedUpdate()
    {
        MoveBullet();
    }

    private void Update()
    {
        CheckOutScreen();
    }

    private void RotateBulletToPlayer()
    {
        moveDirection = (EnemyManager.Instance.player.transform.position - transform.position).normalized; // 임시로 EnemyManager 참조

        float rotZ = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + Random.Range(-80f, 80f);

        moveDirection = Quaternion.AngleAxis(rotZ, Vector3.up) * moveDirection;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }


    private void MoveBullet()
    {
        rb2D.velocity = moveDirection * speed ;
    }

    private void CheckOutScreen()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackCharacter();
            //collision.gameObject.GetComponent<ICharacter>().TakeDamage();
        }
    }
}
