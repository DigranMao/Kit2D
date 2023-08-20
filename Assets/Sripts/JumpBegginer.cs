using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBegginer : MonoBehaviour
{
    public KeyCode number1;
    public KeyCode number2;
    Animator anim;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if(Input.GetKey(number1))
        {
            anim.SetInteger("Panel", 1);
        }
        if(Input.GetKey(number2))
        {
            anim.SetInteger("Panel", 2);
        }
    }
}
