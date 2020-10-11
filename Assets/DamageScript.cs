using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    public Animator animator;
    public AudioSource audioSource;

    public int maxHealth;
    int currentHealth;
    int hitCounter;


    bool isDead = false;
    
    
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
        hitCounter++;
        if (!isDead)
        {
            currentHealth -= (damage/2);
            if (audioSource != null)
            { audioSource.Play(); }
            animator.SetTrigger("IFTakenHit");

        }
        if (currentHealth <= 0)
        {
            Die();
            isDead = true;
        }

    }

    void Die() 
    {
        animator.SetBool("IfDead", true);
        Debug.Log("Enemy Died!"+"Enemy was hit "+ (hitCounter/2) );


        if (GetComponent<EnemyJumpScript>() != null)
        {
            GetComponent<EnemyJumpScript>().enabled = false;
        }
        if (GetComponent<EnemyScript>() != null)
        {
            GetComponent<EnemyScript>().enabled = false;
        }
        
        GetComponent<Rigidbody2D>().Sleep();
       



            this.enabled = false;
    
    }


}
