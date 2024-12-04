using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloseScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D body;
    private int direction = 1;
    private float bound = 1f;
    private float xpos;
    private SpriteRenderer spriteRenderer;

    public int speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        xpos = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        body.transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);
        if (Mathf.Abs(xpos - body.transform.position.x) >= bound)
        {
            direction = -direction;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
