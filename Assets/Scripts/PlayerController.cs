using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    public RuntimeAnimatorController[] listAnimator;
    public int state;
    
    private Transform frontCheck;

    private bool attack = false;
    private bool attacked;

    private EnemyController enemy;
    float hp = 1000;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("attack", attack);
        frontCheck = transform.Find("frontCheck").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
	}

    public void FlipRight()
    {
        attack = true;
        animator.SetBool("attack", attack);
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
    }

    public void FlipLeft()
    {
        attack = true;
        animator.SetBool("attack", attack);
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
    }       
    public void IdleState()
    {
        // Chuyển về trạng thái Idle sau khi Attack xong
        attack = false;
        animator.SetBool("attack", attack);
    }

    void FixedUpdate()
    {
        Collider2D[] frontEnemy = Physics2D.OverlapPointAll(frontCheck.position);
        foreach (Collider2D c in frontEnemy)
        {
            if (c.tag == "Enemy") 
            {
                
            }
        }
    }

    void Update()
    {
        animator.runtimeAnimatorController = listAnimator[state];
        if (enemy.attackEnemy == true)
        {
            //Debug.Log("a" + hp);
            hp--;
            if (hp <= 950)
            {
                state--;
                hp = 1000;
            }
            if (state<=0)
            {
                Destroy(gameObject);
            }
        }
    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.tag == "Enemy")
    //    {
    //        Debug.Log("player is attacked");
    //        attacked = true;
    //    }
    //}

}
