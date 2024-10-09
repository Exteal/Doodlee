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
        animator = transform.Find("Body").GetComponent<Animator>();
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
                
                if(Doodle_Is_Under(collision))
                {
                    
                    doodle.velocity = new Vector3(doodle.velocity.x, 0);
                    doodle.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    animator.Play("Jump");
                    collision.gameObject.GetComponent<AudioSource>().Play();
                }
                
            }

            if(collision.CompareTag("brown_platform") && Doodle_Is_Under(collision))
            {
                if (Doodle_Is_Under(collision))
                {
                    collision.gameObject.SendMessage("Break");
                }
            }


            return;            
        }
            
    }

    private bool Doodle_Is_Under(Collider2D other)
    {
        return doodle.transform.position.y > other.transform.position.y;
    }
}


