using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    private BonusFactory springFactory;
    private BonusFactory capFactory;

    public GameObject doodle;
    public GameObject cam;

    public GameObject[] walls;
    
    void Start()
    {

        springFactory = GetComponent<SpringFactory>();
        capFactory = GetComponent<CapFactory>();

    }

    public bool hasBonus()
    {
        return UnityEngine.Random.Range(0, 101) < 10;
    }

    public GameObject selectBonus()
    {
        var rd = UnityEngine.Random.Range(0, 101);

        BonusFactory factory = null;

        switch(rd)
        {
            case var _ when rd <= 50:

                factory = springFactory;
                break;

            case var _ when rd <= 100:
                factory = capFactory;
                break;
            
            default:
                break;
        }

        return factory.ReturnBonus();
    }

    private void Update()
    {
        var difference = cam.transform.InverseTransformPoint(doodle.transform.position).y;

        if (difference <= 0)
        {
            return;
        }

        cam.transform.Translate(new Vector2(0, difference));
        foreach (var wall in walls)
        {
            wall.transform.Translate(new Vector2(0, difference));
        }

    }
}
