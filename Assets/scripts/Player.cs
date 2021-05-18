using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed, jumpForce;
    // float time;
    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // time = time + (1 + Time.deltaTime);
        float currentSpeed = 0;
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed = -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentSpeed = speed;
        }
        rigidbody.velocity = new Vector2(currentSpeed, rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
             rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
           //  rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }
}
