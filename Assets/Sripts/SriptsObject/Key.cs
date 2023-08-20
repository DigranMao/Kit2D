using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    KeyUI KeyUISript;
    //AudioSource openAudio;

    void Start()
    {
        //openAudio = GetComponent<AudioSource>();
        KeyUISript = GameObject.Find("Canvas").GetComponent<KeyUI>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            KeyUISript.KeyUp(1);
            //openAudio.Play();
            Destroy(gameObject);
        }
    }
}
