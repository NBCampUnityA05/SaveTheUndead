using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contacts = collision.contacts;
        foreach( ContactPoint contact in contacts ) 
        {
            Bullet isbullet = contact.otherCollider.GetComponent<Bullet>();
            if (isbullet != null)
            {
                isbullet.TakeDamage();
            }
        }

        Destroy(this);
    }
}
