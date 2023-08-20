using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 1;
    public Transform StaffAttack;
    public bool notActive = true;
    SpriteRenderer sprite;
    Animator anim;

    public float attackRange = 0.5f;
    public LayerMask enemy;

    Collider2D hitEnemy;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && notActive)
        {
            anim.SetTrigger("StaffAttack");
        }

        if(sprite.flipX)
        {
            StaffAttack.localPosition = new Vector2(-2, 0.81f);
        }
        else
        {
            StaffAttack.localPosition = new Vector2(2, 0.81f);
        }
    }

    void FixedUpdate()
    {
        hitEnemy = Physics2D.OverlapCircle(StaffAttack.position, attackRange, enemy);
    }

    void AttackHit()
    {
        hitEnemy.GetComponent<HealthEnamy>().TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(StaffAttack.position, attackRange);
    }
}
