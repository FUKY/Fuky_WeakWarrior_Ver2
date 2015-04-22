using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    private Animator animatorEnemy;
    public bool attackEnemy = false;
    private Transform frontCheck;

    //public float SPEED_DEFAULT = 2f;

    public float speed = 2f;
    private Rigidbody2D rb2d;


   // private EnemyController enemy;
    private bool death;
    private bool playerAttack;

    void Start()
    {
        animatorEnemy = GetComponent<Animator>();
        frontCheck = transform.Find("frontCheck").transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);
        foreach (Collider2D c in frontHits)
        {
            // Attack khi frontCheck chạm vào Player
            if (c.tag == "Player")
            {
                attackEnemy = true;
                rb2d.velocity = new UnityEngine.Vector2(0f, 0f);
                animatorEnemy.SetBool("attackEnemy", attackEnemy);
            }
            // Enemy bị chém trúng
            else
                if (c.tag == "Sword")
                {
                    death = c.GetComponentInParent<PlayerController>().attack;
                    if (death == true)
                    {
                        Destroy(gameObject);
                    }
                }            
        }
    }

    public void SetVellocity(bool left)
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (left)
        {
            transform.localScale = new UnityEngine.Vector3(1, 1, 1);
            rb2d.velocity = new UnityEngine.Vector2(speed, 0f);
        }
        else
        {
            transform.localScale = new UnityEngine.Vector3(-1, 1, 1);
            rb2d.velocity = new UnityEngine.Vector2(-speed, 0f);
        }
    }
    // Enemy bị chém trúng
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Sword")
    //    {
    //        if (other.tag == "Sword")
    //        {
    //            playerAttack = other.GetComponentInParent<Animator>().GetBool("attack");
    //            Debug.Log(playerAttack);
    //            if (playerAttack == true)
    //            {
    //                Destroy(gameObject);
    //            }
    //        }
    //    }
    //}
}
