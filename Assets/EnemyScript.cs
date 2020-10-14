using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //FOR TRACKING PLAYER
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    // [SerializeField] float moveSpeed;
    [SerializeField] float stopDistance;
    [SerializeField] float scale = 1;
    [SerializeField] bool showDebugLine;
    [SerializeField] Transform castPoint;
    //Rigidbody2D rb2d;
    bool isFacingLeft;
    bool isAgro = false;
    bool isSearching = false;
    float distToPlayer;
    float castDist;

    //FOR MOVEMENT
    float dirX;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] private LayerMask whatIsJumpable;
    [SerializeField] private LayerMask whatIsEdge;
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform jumpCheck;
    [SerializeField] private Transform edgeCheck;
    Rigidbody2D rb2d;
    bool facingRight = true;
    Vector3 localScale;
    const float radius = .1f;



    bool ifSeePlayer = false;

    bool globalIsLeft=false;

    float jumpMod = 240f;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        if (ifSeePlayer == false)
        {
            print("dasdas");
            dirX = 1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (CanSeePlayer(agroRange))
        {
            ifSeePlayer = true;
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
                    Invoke("StopChasingPlayer", 5);

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

    void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(11, 11);

        if (ifSeePlayer == false)
        {




            rb2d.velocity = new Vector2(dirX * moveSpeed, rb2d.velocity.y);

            Collider2D[] collidersJump = Physics2D.OverlapCircleAll(jumpCheck.position, radius, whatIsJumpable);
            for (int i = 0; i < collidersJump.Length; i++)
            {
                if (collidersJump[i].gameObject != gameObject)
                {
                    rb2d.AddForce(Vector2.up * jumpMod);
                }
            }

            Collider2D[] collidersWall = Physics2D.OverlapCircleAll(wallCheck.position, radius, whatIsWall);
            for (int i = 0; i < collidersWall.Length; i++)
            {
                if (collidersWall[i].gameObject != gameObject)
                {
                    moveChangeDir();
                }
            }

            Collider2D[] collidersEdge = Physics2D.OverlapCircleAll(edgeCheck.position, radius, whatIsEdge);
            for (int i = 0; i < collidersEdge.Length; i++)
            {
                if (collidersEdge[i].gameObject != gameObject)
                {
                    moveChangeDir();
                }
            }
        }


    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        
        castDist = distance;

        if (globalIsLeft)
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
        if (transform.position.x < ((float)player.position.x - (float)stopDistance))
        {
            //move right
            print("right");
            Collider2D[] collidersJump = Physics2D.OverlapCircleAll(jumpCheck.position, radius, whatIsJumpable);
            for (int i = 0; i < collidersJump.Length; i++)
            {
                if (collidersJump[i].gameObject != gameObject)
                {
                    rb2d.AddForce(Vector2.up * jumpMod);
                }
            }
            isFacingLeft = false;
            globalIsLeft = false;
            moveChangeDir();
        }
        else if (transform.position.x > ((float)player.position.x + (float)stopDistance))
        {
            //move left
            print("left");
            Collider2D[] collidersJump = Physics2D.OverlapCircleAll(jumpCheck.position, radius, whatIsJumpable);
            for (int i = 0; i < collidersJump.Length; i++)
            {
                if (collidersJump[i].gameObject != gameObject)
                {
                    rb2d.AddForce(Vector2.up * jumpMod);
                }
            }
            isFacingLeft = true;
            globalIsLeft = true;
            moveChangeDir();
        }
    }

    void StopChasingPlayer()
    {
        if (ifSeePlayer = true)
        {
            //dirX = 0f;
        }
        ifSeePlayer = false;
        isAgro = false;
        isSearching = false;
        //rb2d.velocity = new Vector2(0, 0);
    }

    public void moveChangeDir()
    {
        print("ifSeePlayer: "+ifSeePlayer);
        if (ifSeePlayer == false)
        {
            facingRight = !facingRight;

            if (facingRight)//RIGHT
            {
                dirX = 1f;
                globalIsLeft = false;
            }
            else if (!facingRight)//LEFT
            {
                dirX = -1f;

                globalIsLeft = true;
            }
            rb2d.velocity = new Vector2(dirX * (moveSpeed), rb2d.velocity.y);
            if (((facingRight) && (localScale.x < 0) || ((!facingRight) && (localScale.x > 0))))
            {
                localScale.x *= -1;
            }
            transform.localScale = localScale;
        }
        else if(ifSeePlayer == true) {
            
            if (!isFacingLeft)//RIGHT
            {
                dirX = 1f;
                globalIsLeft = false;
            }
            else if (isFacingLeft)//LEFT
            {
                dirX = -1f;
                globalIsLeft = true;
            }
            rb2d.velocity = new Vector2(dirX * (moveSpeed), rb2d.velocity.y);
            if (((!isFacingLeft) && (localScale.x < 0) || ((isFacingLeft) && (localScale.x > 0))))
            {
                localScale.x *= -1;
            }
            transform.localScale = localScale;
        }

    }


}
