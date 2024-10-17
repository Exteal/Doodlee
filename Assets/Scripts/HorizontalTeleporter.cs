using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HorizontalTeleporter : MonoBehaviour
{

    private float bound;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bound = math.abs(transform.position.x) - math.abs(spriteRenderer.sprite.bounds.size.x);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                int direction = collision.transform.position.x < 0 ? 1 : -1;
                //float wd = Camera.main.orthographicSize * Camera.main.aspect;
                collision.transform.Translate(new Vector2(bound * 2 *  direction, 0));
            }


        }
    }
}
