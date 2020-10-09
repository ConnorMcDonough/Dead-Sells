using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpScript : MonoBehaviour
{

    float dirX;

    [SerializeField] float moveSpeed = 3f;

    [SerializeField] private LayerMask whatIsJumpable;
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private Transform jumpCheck;

    Rigidbody2D rb2d;

    bool facingRight = true;

    Vector3 localScale;

    const float jumpRadius = .1f;
    const float wallRadius = .1f;



    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb2d = GetComponent<Rigidbody2D>();
        dirX = 1f;
    }

    void FixedUpdate()
    {

        Physics2D.IgnoreLayerCollision(11, 11);



        rb2d.velocity = new Vector2(dirX * moveSpeed, rb2d.velocity.y);

        Collider2D[] collidersJump = Physics2D.OverlapCircleAll(jumpCheck.position, jumpRadius, whatIsJumpable);
        for (int i = 0; i < collidersJump.Length; i++)
        {
            if (collidersJump[i].gameObject != gameObject)
            {
                rb2d.AddForce(Vector2.up * 600f);
            }
        }

        Collider2D[] collidersWall = Physics2D.OverlapCircleAll(wallCheck.position, wallRadius, whatIsWall);
        for (int i = 0; i < collidersWall.Length; i++)
        {
            if (collidersWall[i].gameObject != gameObject)
            {
                facingRight = !facingRight;
                if (facingRight)
                {
                    dirX = 1f;
                }
                else if (!facingRight)
                {
                    dirX = -1f;
                }
                rb2d.velocity = new Vector2(dirX * moveSpeed, rb2d.velocity.y);
                if (((facingRight) && (localScale.x < 0) || ((!facingRight) && (localScale.x > 0))))
                {
                    localScale.x *= -1;
                }
                transform.localScale = localScale;
            }
        }

    }


}
