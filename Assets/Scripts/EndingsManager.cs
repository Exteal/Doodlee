using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsManager : MonoBehaviour
{

    public Camera mainCamera;
    public Canvas endUI;
    public GameObject bgEnd;

    public GameObject plateforms;
    public GameObject obstacles;
    public Rigidbody2D doodle;

    void Start()
    {
        endUI.enabled = false;
    }


    public void FellOff()
    {
        mainCamera.transform.Translate(new Vector2(0, -10));
        endUI.enabled = !(endUI.enabled);

        bgEnd.GetComponent<AudioSource>().Play();

        destroyElements();

    }

    public void FreeFall()
    {
        
        doodle.velocity = new Vector3(doodle.velocity.x, 0);
        doodle.AddForce(new Vector2(0, -2), ForceMode2D.Impulse);
        Destroy(doodle.GetComponent<PlayerCollider>());
        Destroy(doodle.GetComponent<PlayerController>());

    }

    private void destroyElements()
    {
        Destroy(plateforms);
        Destroy(obstacles);
    }
}
