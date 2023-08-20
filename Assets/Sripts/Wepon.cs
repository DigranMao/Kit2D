using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public Transform PointLeft;
    public Transform PointRight;
    public GameObject bulletPrefab;

    private float timeShot;
    public float startTimeShot;
    
    public SpriteRenderer sprite;
    bool shoot = false;
    
    void Update()
    {
        if(timeShot <= 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                if(shoot)
                {
                    Shoot();
                }
                
                timeShot = startTimeShot;             
            }
        }
        else
        { 
            timeShot -= Time.deltaTime; 
        }        
    }

    public void ShootTrue(bool shootTrue)
    {
        shoot = shootTrue;
    }

    void Shoot()
    {
        if(sprite.flipX)
        {
            Instantiate(bulletPrefab, PointLeft.position, PointLeft.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, PointRight.position, PointRight.rotation);
        }
        
    }
}
