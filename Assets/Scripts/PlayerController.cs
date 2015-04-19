using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    public RuntimeAnimatorController[] listAnimator;
    public int state;
    
    //private Transform frontCheck;

    public bool attack = false;
    private bool attacked;

	void Start () {
        animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = listAnimator[state];
        animator.SetBool("attack", attack);
        //frontCheck = transform.Find("frontCheck").transform;
	}

    public void FlipRight()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
        attack = true;
        animator.SetBool("attack", attack);
    }

    public void FlipLeft()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
        attack = true;
        animator.SetBool("attack", attack);
    }       
    public void IdleState()
    {
        // Chuyển về trạng thái Idle sau khi Attack xong
        attack = false;
        animator.SetBool("attack", attack);
    }

    //void FixedUpdate()
    //{
    //    Collider2D[] frontEnemy = Physics2D.OverlapPointAll(frontCheck.position);
    //    foreach (Collider2D c in frontEnemy)
    //    {
    //        // Player bị chém
    //        attacked = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>().attackEnemy;
    //        Debug.Log(attacked);
    //        // Player chém trúng Enemy
    //        if (c.tag == "Enemy" && animator.GetBool("attack") == true)
    //        {
    //            //Debug.Log("enemyDeath");
    //            enemyDeath = true;
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            
        }
    }

}
