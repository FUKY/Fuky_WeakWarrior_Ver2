using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    public RuntimeAnimatorController[] listAnimator;
    public int state;
    
    private Transform frontCheck;

    public bool attack = false;
    private bool attackOn;
    private bool attacked;

    public GameObject sword;

    private EnemyController enemy;
    float hp = 1000;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        attack = false;
        sword.SetActive(attack);
        animator.SetBool("attack", attack);
        frontCheck = transform.Find("frontCheck").transform;
       // enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        animator.runtimeAnimatorController = listAnimator[state];
	}

    public void FlipRight()
    {
        //attack = true;
        animator.SetBool("attack", true);
        sword.SetActive(false);
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
    }

    public void FlipLeft()
    {
        //attack = true;
        animator.SetBool("attack", true);
        sword.SetActive(false);
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
    }       
    public void IdleState()
    {
        // Chuyển về trạng thái Idle sau khi Attack xong
        attack = false;
        animator.SetBool("attack", attack);
        sword.SetActive(attack);
        
    }

    //void FixedUpdate()
    //{
    //    Collider2D[] frontEnemy = Physics2D.OverlapPointAll(frontCheck.position);
    //    foreach (Collider2D c in frontEnemy)
    //    {
    //        if (c.tag == "Enemy") 
    //        {
                
    //        }
    //    }
    //}

    public void AttackState()
    {
        attack = true;
        sword.SetActive(attack);
        //animator.SetBool("attack", attack);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("player is attacked");
            attacked = true;
            if (state<=0)
            {
                Destroy(gameObject);
            }
            else
            {
                state--;
                animator.runtimeAnimatorController = listAnimator[state];
            }
            
        }
    }

}
