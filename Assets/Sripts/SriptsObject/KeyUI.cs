using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    public static int sumKey;
    public Animator key1;
    public Animator key2;
    public Animator key3;
    public Door door;
    AudioSource keyAudio;

    void Start()
    {
        keyAudio = GetComponent<AudioSource>();
    }

    public void KeyUp(int number)
    {
        sumKey += number;
        if(sumKey == 1)
        {
            keyAudio.Play();
            key1.SetTrigger("Key");
        }
        if(sumKey == 2)
        {
            keyAudio.Play();
            key2.SetTrigger("Key");
        }
        if(sumKey == 3)
        {
            keyAudio.Play();
            key3.SetTrigger("Key");
            door.OpenDoor();//true
        }
    }

}
