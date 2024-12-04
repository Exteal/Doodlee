using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum BounceSign
{
    Positive,
    Negative,
    None
}

public class MoveEdgesOfScreen : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private int direction = 1;
    private float bound = 2.6f;
    private BounceSign bounceSign = BounceSign.None;

    public int speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        body.transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);
        if (Mathf.Abs(body.transform.position.x) >= bound)
        {
            
            switch(bounceSign)
            {
                case BounceSign.None:
                    bounceSign = body.transform.position.x > 0 ? BounceSign.Positive : BounceSign.Negative;
                    Bounce();
                    break;

                case BounceSign.Positive:
                    if(body.transform.position.x > 0)
                    {
                        return;
                    }
                    Bounce();
                    break;
                
                case BounceSign.Negative:
                    if (body.transform.position.x < 0)
                    {
                        return;
                    }
                    Bounce();
                    break;
            }
            
        }
    }

    private void Bounce()
    {
        direction = -direction;
        spriteRenderer.flipX = !spriteRenderer.flipX;

    }
}



