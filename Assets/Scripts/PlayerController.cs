using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D doodle;
    private int speed;
    private float dire;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    void Start()
    {
        doodle = GetComponent<Rigidbody2D>();
        speed = 3;
        dire = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        doodle.transform.Translate(new Vector2(dire, 0) * speed * Time.deltaTime);
        spriteRenderer.flipX = dire == -1;
    }

    void OnShoot()
    {
        animator.Play("Shoot");

    }

    void OnMove(InputValue inputValue)
    {
        var moveVal = inputValue.Get<float>();
        dire = moveVal;
        
    }
}
