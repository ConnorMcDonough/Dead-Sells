using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange;

    [SerializeField] float moveSpeed;

    [SerializeField] float stopDistance;

    [SerializeField] float scale = 1;

    [SerializeField] bool showDebugLine;

    //[SerializeField] float stopDistance = 1;

    [SerializeField] Transform castPoint;

    Rigidbody2D rb2d;

    bool isFacingLeft;
    bool isAgro = false;
    bool isSearching = false;

    float distToPlayer;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        /* NO LONGER NEEDED BUT I KEEP IT HERE BECAUSE I LOVE IT <3
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange && distToPlayer > stopDistance)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }
        */

        if (CanSeePlayer(agroRange))
        {
            isAgro = true;
            ChasePlayer();
        }
        else
        {
            if (isAgro == true)
            {

                if (!isSearching)
                {
                    isSearching = true;

                    Invoke("StopChasingPlayer", 2);

                }

            }
            else
            {
                StopChasingPlayer();
            }

        }

        if (isAgro)
        {
            ChasePlayer();
        }


    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (isFacingLeft == true)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.right * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
            if (showDebugLine == true)
            {
                Debug.DrawLine(castPoint.position, hit.point, Color.red);
            }


        }
        else
        {
            if (showDebugLine == true)
            {
                Debug.DrawLine(castPoint.position, endPos, Color.blue);
            }

        }
        return val;
    }

    void ChasePlayer()
    {
        print("Trans: " + transform.position.x);
        print("play: " + player.position.x);
        print("play+stop: " + ((float)player.position.x + (float)stopDistance));
        if (transform.position.x < ((float)player.position.x - (float)stopDistance))
        {
            //move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(scale, scale);
            isFacingLeft = false;
        }
        else if (transform.position.x > ((float)player.position.x + (float)stopDistance))
        {
            //move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-scale, scale);
            isFacingLeft = true;


        }
    }

    void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
    }


}
