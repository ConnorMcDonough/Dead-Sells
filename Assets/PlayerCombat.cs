using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Animator animator;

    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform attackPoint3;

    public float attackRange= .05f;
    public float attackRange2 = .05f;
    public float attackRange3 = .05f;
   
    public int attackDamage = 20;

    public LayerMask enemyLayers;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            
             Attack(); 
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
           
             Attack2(); 
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            
             Attack3(); 
        }
    }



    void Attack() {

        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
           enemy.GetComponent<DamageScript>().TakeDamage(attackDamage);
            

        }


    }

    void Attack2() {

        animator.SetTrigger("Attack2");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<DamageScript>().TakeDamage(attackDamage);
            
        }

    }

    void Attack3()
    {

        animator.SetTrigger("Attack3");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<DamageScript>().TakeDamage(attackDamage);

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange3);
    }



}
