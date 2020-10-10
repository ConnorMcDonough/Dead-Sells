using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    public Animator animator;
    

    public int maxHealth;
    int currentHealth;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("IFTakenHit");

        if (currentHealth <= 0)
        {
            Die();
        
        }

    }

    void Die() 
    {
        animator.SetBool("IfDead", true);
        Debug.Log("Enemy Died!");


        if (GetComponent<EnemyJumpScript>() != null)
        {
            GetComponent<EnemyJumpScript>().enabled = false;
        }
        if (GetComponent<EnemyScript>() != null)
        {
            GetComponent<EnemyScript>().enabled = false;
        }
        
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

       









            this.enabled = false;
    
    }


}
