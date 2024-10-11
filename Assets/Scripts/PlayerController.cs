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
    private float facingDire;


    private Animator bodyAnimator;
    private Animator mouthAnimator;

    private SpriteRenderer bodySprite;



    void Start()
    {
        doodle = GetComponent<Rigidbody2D>();
        speed = 3;
        dire = 0;
        
        bodySprite = transform.Find("Body").GetComponent<SpriteRenderer>();
        bodyAnimator = transform.Find("Body").GetComponent<Animator>();
        mouthAnimator = transform.Find("Mouth").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        doodle.transform.Translate(new Vector2(dire, 0) * speed * Time.deltaTime);
        bodySprite.flipX = facingDire == -1;
        
        //Debug.Log(mouthAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
    }

    void OnShoot()
    {
        bodyAnimator.Play("Shoot");
        mouthAnimator.Play("Shooting");
    }

    void OnMove(InputValue inputValue)
    {
        var moveVal = inputValue.Get<float>();
        facingDire = moveVal != 0 ? moveVal : facingDire;
        dire = moveVal;        
    }
}
