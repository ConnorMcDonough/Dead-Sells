using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{

    public float attackRange = .05f;
    public int attackDamage = 5;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Transform attackPoint;

    public Transform target;
    private float distToPlayer;

    public Animator animator;

    public LayerMask playerMask;


    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, target.position);


        if (Time.time >= nextAttackTime)
        {
            if (distToPlayer <= attackRange)
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
                //Check if target is Close enough if so
                //Attack but only attack every second or so no more
            }
        }   
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);

        foreach (Collider2D player in hitEnemies)
        {
            Debug.Log("We hit" + player.name);
            player.GetComponent<DamageScriptPlayer>().TakeDamage(attackDamage);


        }


    }


        private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
     
    }
}
