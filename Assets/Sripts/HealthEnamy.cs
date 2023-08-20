using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnamy : MonoBehaviour
{
    public int health = 25;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            anim.SetTrigger("Hurt");
            Invoke("Die", 0.75f);
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }

    
}
