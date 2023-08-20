using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int dps = 1;

    public Transform PointRadius;
    public Transform point;
    Transform player;

    public float speed;
    public float stopingDistace;
    public int positionPatrol;

    public float attack;

    SpriteRenderer sprite;
    bool moveing;

    bool chill = false;
    bool angry = false;
    bool goBack = false;
    bool die = true;
    
    bool angryAttack = false;
    Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask players;
    private float attackShot;
    public float attackTimeShot;

    Collider2D hitPlayer;


    /*UnityEngine.Object enemyRef;
    public float timeDestroy = 5f;    
    Vector3 spawnPos;*/

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //enemyRef = Resources.Load("Enemy");
        //spawnPos = transform.position;
    }

    void Update()
    {
        if(die)
        {
            if(Vector2.Distance(transform.position, point.position) < positionPatrol && angry == false)
            {
                chill = true;
            }        
            if(Vector2.Distance(transform.position, player.position) < stopingDistace && angryAttack == false)
            {
                angry = true;
                chill = false;
                goBack = false;
                
            }          
            if(Vector2.Distance(transform.position, player.position) > stopingDistace)
            {
                goBack = true;
                angry = false;
            }
            
            if(hitPlayer)
            {
                angry = false;
                chill = false;
                goBack = false;
                angryAttack = true;
                anim.SetBool("Idle", true); 
                anim.SetBool("Run", false);
                if(attackShot <= 0)
                {
                    anim.SetTrigger("Attack"); 
                    attackShot = attackTimeShot;        
                }
                else
                {
                    attackShot -= Time.deltaTime; 

                }             
            }               
            if(!hitPlayer)
            {
                angryAttack = false;
                anim.SetBool("Idle", false); 
            } 

            if(chill == true)
            {
                Chill();
                anim.SetBool("Run", false);
            }
            else if(angry == true)
            {
                Angry();
            }
            else if(goBack == true)
            {
                GoBack();
                anim.SetBool("Run", false);
            }
        }
    }

    /*public void TakeDamage(int damage)
    {
        health -= damage;
        
        if(health <= 0)
        {
            anim.SetTrigger("Hurt");
            die = false;
            Invoke("Die", 0.75f);
        }
    }*/

    void FixedUpdate()
    {
        hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, players);
    }

    void ShotingAttack()
    {
        hitPlayer.GetComponent<HealthPlayer>().TakeDamagePlayer(dps);
    }

    void Chill()
    {
        if(transform.position.x > point.position.x + positionPatrol)
        {
            moveing = false;
        }
        else if (transform.position.x < point.position.x - positionPatrol)
        {
            moveing = true;
        }
        
        if(moveing)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }       
    }

    void Angry()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        anim.SetBool("Run", true); 
        Vector2 target = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime );
        Flip();        
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

        if(transform.position.x < point.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(transform.position.x > point.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Flip()
    {
        if(transform.position.x < player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(transform.position.x > player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(PointRadius.position, stopingDistace);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
