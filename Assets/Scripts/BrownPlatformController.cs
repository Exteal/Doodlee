using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownPlatformController : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animator;
    private int falling;
    private Rigidbody2D plateform;
    private int speed = 3;
    private AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        falling = 0;
        plateform  = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        plateform.transform.Translate(new Vector2(0, falling) * speed * Time.deltaTime);
    }

    private void Break()
    {
        animator.Play("Break");
        audioSource.PlayOneShot(audioSource.clip);
        falling = -1;
    }
}
