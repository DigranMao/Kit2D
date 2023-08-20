using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    Rigidbody2D rb;

    public float destroyTime = 5;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet", destroyTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        HealthEnamy enemy = hitInfo.GetComponent<HealthEnamy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
