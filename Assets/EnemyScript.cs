using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange;

    [SerializeField] float moveSpeed;

    [SerializeField] float scale=1;

    [SerializeField] float stopDistance=1;

    Rigidbody2D rb2d;
    


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange && distToPlayer>stopDistance)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }

    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(scale,scale);
        }
        else if (transform.position.x > player.position.x)
        {
            //move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-scale,scale);
            
            
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity= Vector2.zero;
    }


}
