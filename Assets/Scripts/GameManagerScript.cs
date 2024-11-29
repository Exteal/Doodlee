using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    private BonusFactory springFactory;
    private BonusFactory capFactory;

    private PlatformFactory platformFactory;

    public GameObject doodle;
    public GameObject cam;

    public GameObject[] walls;

    private PlayerController controller;

    private EnemyFactory enemyFactory;

    private float lastGenPoint;


    
    void Start()
    {

        springFactory = GetComponent<SpringFactory>();
        capFactory = GetComponent<CapFactory>();

        controller = doodle.GetComponent<PlayerController>();
        platformFactory = GetComponent<PlatformFactory>();
        enemyFactory = doodle.GetComponent<EnemyFactory>();

        lastGenPoint = 0;

        CreateInitPlateforms();

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
        MoveObjects();
        CreatePlateforms();
    }

    
    
    private void CreateInitPlateforms()
    {

        var pos = doodle.transform.position;
        var limit = platformFactory.ahead;
        var inters = platformFactory.interst;
        


        platformFactory.CreatePlateform(pos, -1.2f);

      
        for (float i = (float)Math.Floor(pos.y) ; i < limit ;  i = i+inters)
        {
            if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
            {
                var x = UnityEngine.Random.Range(-3.7f, 3.7f);
                platformFactory.CreatePlateform(new Vector2(x, i));
            }
        }
    }
    private void CreatePlateforms()
    {
        var highest = controller.GetHighest();
        var ahead = platformFactory.ahead;
        var doodleHt = (int)Math.Floor(doodle.transform.position.y * 2) / 2;


        if (doodleHt > lastGenPoint)
        {
    
            var creat = UnityEngine.Random.Range(0f, 1f) >= 0.5f;
          
            if (creat)
            {

                var x = UnityEngine.Random.Range(-3.7f, 3.7f);
                platformFactory.CreatePlateform(new Vector2(x, doodleHt + ahead));
                
            }

            lastGenPoint = doodleHt;
                 
        }
    }

    private void CreateEnemy()
    {
        var highest = controller.GetHighest();
        var ahead = platformFactory.ahead;
        var doodleHt = (int)Math.Floor(doodle.transform.position.y * 2) / 2;

        var dist_between_enemies = 10;

        if (doodleHt > lastGenPoint + dist_between_enemies)
        {

            var creat = UnityEngine.Random.Range(0f, 1f) >= 0.1f;

            if (creat)
            {
                var x = UnityEngine.Random.Range(-3.7f, 3.7f);
                enemyFactory.CreateEnemy(new Vector2(x, doodleHt + ahead));
            }

            lastGenPoint = doodleHt;

        }

    }

    private void MoveObjects()
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
