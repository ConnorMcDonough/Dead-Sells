using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{


    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] 
    public Animator animator;
    public AudioSource audioSource;

    public int maxHealth;
    int currentHealth;
    int hitCounter;

    bool addDeathCounter =false;


    bool isDead = false;

    
    public HeadCounter headCounter;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.x != 0)
        {
            animator.SetBool("ifWalking", true);
        }
        else if (rb2d.velocity.x == 0)
        {
            animator.SetBool("ifWalking", false);
        }
    }

    public void TakeDamage(int damage)
    {
        hitCounter++;
        if (!isDead)
        {
            currentHealth -= (damage / 2);
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
        Debug.Log("Enemy Died!" + "Enemy was hit " + (hitCounter / 2));

        if(addDeathCounter==false) {
                headCounter.addHeadCount();
                addDeathCounter=true;
            }


        if (GetComponent<EnemyMoveScript>() != null)
        {
            GetComponent<EnemyMoveScript>().enabled = false;
        }
        if (GetComponent<EnemyScript>() != null)
        {
            GetComponent<EnemyScript>().enabled = false;
        }
        if (GetComponent<playerMovement>() != null)
        {
            GetComponent<playerMovement>().enabled = false;
        }
        if (GetComponent<PlayerCombat>() != null)
        {
            GetComponent<PlayerCombat>().enabled = false;
        }
        if (GetComponent<EnemyAttackScript>() != null)
        {
            GetComponent<EnemyAttackScript>().enabled = false;
        }



        GetComponent<Rigidbody2D>().Sleep();




        this.enabled = false;

    }


}
