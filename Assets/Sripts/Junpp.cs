using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junpp : MonoBehaviour
{
    public float jumpForce = 100f; // сила прижка
    private int jumpIteration = 0; // при каждой итерации добаляется +1
    public int jumpValue = 60;

    public Transform groundCheck; // точка в которой будем проверять стоит персонаж на земле или нет
    public LayerMask whatIsGraund; // то что мы считаем за землю
    
    public float radius = 0.1f; // радиус вокруг groundCheck
    public bool isGraunded; // можно прыгать или нет
    private bool jumpControl;

    private Rigidbody2D rb;
    private Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        Jumps();
        isGraunded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGraund);

        if(isGraunded == true)
        {
            anim.SetBool("Jump", false);
        }
        else if(isGraunded == false)
        {
            anim.SetBool("Jump", true);
        }              
    }

    void Jumps()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(isGraunded)    
            {
                jumpControl = true;
            } 
        }   
        else
        {
            jumpControl = false;
        }

        if(jumpControl)
        {
            if(jumpIteration++ < jumpValue)
            {
                rb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else { jumpIteration = 0;}
    }
}
