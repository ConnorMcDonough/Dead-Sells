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

        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyJumpScript>().enabled = false;
        GetComponent<Animator>().enabled = false;

        this.enabled = false;
    
    }


}
