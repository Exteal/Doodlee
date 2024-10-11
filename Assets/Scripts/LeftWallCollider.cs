using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallCollider : MonoBehaviour
{
   
    void Start()
    {  
    
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                int direction = collision.transform.position.x < 0 ? 1 : -1;
                float wd = Camera.main.orthographicSize * Camera.main.aspect;
                collision.transform.Translate(new Vector2(wd * 2 * direction, 0));
            }


        }
    }
}
