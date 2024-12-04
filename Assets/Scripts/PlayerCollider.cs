using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private int jumpForce;    
    private Rigidbody2D doodle;
    private Animator animator;
    private Animator equipAnimator;
    private EndingsManager endingsManager;
    public GameObject gameManager;
    public AudioClip bonkSound;

    void Start()
    {
        doodle  = GetComponent<Rigidbody2D>();
        jumpForce = 8;
        animator = transform.Find("Body").GetComponent<Animator>();
        equipAnimator = transform.Find("Equip").GetComponent <Animator>();
        endingsManager = gameManager.GetComponent<EndingsManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision != null)
        {
            if (!collision.enabled)
            {
                return;
            }

            if(collision.CompareTag("green_platform") || collision.CompareTag("blue_platform"))
            {
                
                if(DoodleIsOnTop(collision))
                {
                    DoodleJump();
                    collision.gameObject.GetComponent<AudioSource>().Play();
                }
                
            }

            if(collision.CompareTag("brown_platform") && DoodleIsOnTop(collision))
            {
                collision.gameObject.SendMessage("Break");        
            }

            if (collision.CompareTag("bonus"))
            {

                Bonus bonus = collision.gameObject.GetComponent<Bonus>();

                if (bonus == null)
                {
                    return;
                }

                if ( collision.GetComponent<Bonus>().topUseOnly && !DoodleIsOnTop(collision)) {
                    return;
                }

                
                Animator animator = collision.gameObject.GetComponent<Animator>();
                AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>();

                

                if (bonus.HasEquipAnimation())
                {
                    equipAnimator.runtimeAnimatorController = bonus.EquipAnimation();                   
                }

                if (animator != null)
                {
                    animator.Play("Jumped");
                }

                if (audioSource != null)
                {
                    if(bonus.isOneShot)
                    {
                        AudioSource.PlayClipAtPoint(audioSource.clip, audioSource.transform.position);
                    }
                    else
                    {
                        audioSource.Play();
                    }
                    
                }


                if (bonus.isOneShot)
                {
                    Destroy(bonus.gameObject);
                }
                    
                DoodleJump(modifier: bonus.ComputeJumpPower());
                                      
            }
           
            if (collision.CompareTag("black_hole"))
            {
                endingsManager.FreeFall();
            }

            if (collision.CompareTag("enemy"))
            {
                if(DoodleIsOnTop(collision))
                {
                    Destroy(collision);
                    DoodleJump(2);
                } 

                else
                {
                    endingsManager.FreeFall();
                    var player = collision.GetComponent<AudioSource>();
                    player.clip = bonkSound;
                    player.Play();
                }
                
            }
        }
            
    }

    private bool DoodleIsUnder(Collider2D other)
    {
        return doodle.transform.position.y <= other.transform.position.y;
    }

    private bool DoodleIsOnTop(Collider2D other)
    {
        return doodle.transform.position.y > other.transform.position.y;
    }

    private void DoodleJump(float modifier = 1)
    {
        doodle.velocity = new Vector3(doodle.velocity.x, 0);
        doodle.AddForce(new Vector2(0, jumpForce * modifier), ForceMode2D.Impulse);
        animator.Play("Jump");      
    }
  
}


