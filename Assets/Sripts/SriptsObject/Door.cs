using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    Collider2D coll;
    AudioSource openAudio;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        coll = GetComponent<Collider2D>();
        openAudio = GetComponent<AudioSource>();
    }

    public void OpenDoor()//bool open
    {
        //if(open)
        //{
            anim.SetTrigger("Door");
            coll.isTrigger = true;
            openAudio.Play();
        //}
    }
}
