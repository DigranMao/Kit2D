using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int health = 5;

    public int numOfHearts;
    public Animator[] animHealth; 

    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    

    public void TakeDamagePlayer(int damage)
    {
        health -= damage;
        anim.SetTrigger("Hurt");
        rb.AddForce(Vector2.up * 6, ForceMode2D.Impulse);

        if(health < numOfHearts)
        {
            numOfHearts = health;
            animHealth[numOfHearts].SetTrigger("hit");
        }

        /*if(health <= 0)
        {
            anim.SetTrigger("Hurt");
        }*/
    }

    // Update is called once per frame
    void Update()
    {

        
        /*if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < animHealth.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                animHealth[i].SetTrigger("hit");
            }
        }*/
    }
}
