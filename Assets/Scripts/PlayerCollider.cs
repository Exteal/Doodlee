using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private int jumpForce;    
    Rigidbody2D doodle;
    private Animator animator;
    void Start()
    {
        doodle  = GetComponent<Rigidbody2D>();
        jumpForce = 8;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision != null)
        {
            if (!collision.enabled)
            {
                return;
            }

            if(collision.CompareTag("green_platform") || collision.CompareTag("blue_platform") )
            {
                
                if(doodle.transform.position.y > collision.transform.position.y)
                {
                    doodle.velocity = new Vector3(doodle.velocity.x, 0);
                    doodle.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    animator.Play("Jump");
                }
                
            }


            return;            
        }
            
    }
}
