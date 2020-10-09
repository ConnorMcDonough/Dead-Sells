using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpScript : MonoBehaviour
{

    float dirX;

    [SerializeField] float moveSpeed = 3f;

    [SerializeField] private LayerMask whatIsJumpable;

    [SerializeField] private Transform jumpCheck;

    Rigidbody2D rb2d;

    bool facingRight = false;

    Vector3 localScale;

    const float jumpRadius = .1f;

    private bool jumped;


    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb2d = GetComponent<Rigidbody2D>();
        dirX = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(11,11);

        if (transform.position.x < -5f)
        {
            dirX = 1f;
        }
        else if (transform.position.x > 2f)
        {
            dirX = -1f;
        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(dirX * moveSpeed, rb2d.velocity.y);

        bool wasJumped = jumped;
        jumped = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(jumpCheck.position, jumpRadius, whatIsJumpable);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                rb2d.AddForce(Vector2.up * 600f);
            }
        }
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0) || ((!facingRight) && (localScale.x > 0))))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

}
