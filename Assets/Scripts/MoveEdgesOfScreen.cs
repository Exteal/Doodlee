using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEdgesOfScreen : MonoBehaviour
{

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private int direction = 1;
    public int speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        body.transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision != null && collision.enabled && collision.CompareTag("boundary"))
        {     
            Bounce();            
        }
    }

    private void Bounce()
    {
        direction = -direction;
        spriteRenderer.flipX = !spriteRenderer.flipX;

    }
}



