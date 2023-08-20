using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUpSprite2;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponentInChildren<Animator>().SetTrigger("Gun");
            col.gameObject.GetComponentInChildren<Wepon>().ShootTrue(true);
            col.gameObject.GetComponentInChildren<Attack>().notActive = false;
            Instantiate(PickUpSprite2, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
