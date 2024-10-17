using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlateformController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D platform;
    private int direction = 1;
    private int speed = 1;
    private float bound = 3.7f;

    void Start()
    {
        platform = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    
    
    void Update()
    {
        platform.transform.Translate(new Vector2(direction, 0) * speed * Time.deltaTime);
        if (Mathf.Abs(platform.transform.position.x) >= bound)
        {
            direction = -direction;
        }
    }
}
