using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer renderer;
    [SerializeField] private float speed, jumpForce, rayDistance;
    [SerializeField] private LayerMask groundMask;

    // float time;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // time = time + (1 + Time.deltaTime);
        float currentSpeed = 0;
        if (Input.GetKey(KeyCode.A))
        {
            renderer.flipX = true;
            currentSpeed = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            renderer.flipX = false;

            currentSpeed = speed;
        }
        animator.SetFloat("movementSpeed", Mathf.Abs(currentSpeed));
        rigidbody.velocity = new Vector2(currentSpeed, rigidbody.velocity.y);

        if (isGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                //  rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("jumping", true);
            }
            else
            {
                animator.SetBool("jumping", false);

            }

        }
        else
        {
            animator.SetBool("jumping", true);

        }


    }
    private bool isGrounded()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RaycastHit2D hit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, rayDistance, groundMask);

        return hit.collider != null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            bool enemyKilled = false;
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                if (contactPoint.normal.y >= 0.45)
                {
                    enemyKilled = true;
                    break;
                }
            }
            if (enemyKilled)
            {
                Destroy(collision.gameObject);
            }
            else
            {

            }
        }
    }
}
