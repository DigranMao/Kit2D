using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    Vector2 pos;
    bool crouch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            if(crouch == false)
            {
                pos.x =  Input.GetAxis("Horizontal");
                //transform.position = Vector3.MoveTowards(transform.position, transform.position + pos, speed * Time.deltaTime);
                rb.velocity = new Vector2(pos.x * speed, rb.velocity.y);
                
                sprite.flipX = pos.x < 0f;
                anim.SetBool("Run", true);
            }
        }
        else
        {
            rb.velocity = new Vector2(pos.x * 0, rb.velocity.y);
            anim.SetBool("Run", false  );
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = new Vector2(pos.x * 0, rb.velocity.y);
            anim.SetBool("Crouch", true);
            crouch = true;
        }
        else
        {
            anim.SetBool("Crouch", false);
            crouch = false;
        }
    }
}
