using System;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    private PlatformFactory platformFactory;

    public GameObject doodle;
    public GameObject cam;

    public GameObject[] movableObjects;

    private PlayerController controller;

    private EnemyFactory enemyFactory;

    private float lastGeneratedPlateformPoint;

    private float lastGeneratedEnemyPoint;

    private float bound = 2.6f;



    void Start()
    {

        controller = doodle.GetComponent<PlayerController>();
        platformFactory = GetComponent<PlatformFactory>();
        enemyFactory = GetComponent<EnemyFactory>();

        lastGeneratedPlateformPoint = doodle.transform.position.y;
        lastGeneratedEnemyPoint = doodle.transform.position.y;

        CreateInitPlateforms();

    }    
    private void Update()
    {
        MoveObjects();
        CreatePlateform();
        CreateEnemy();
    }

    private void CreateInitPlateforms()
    {
        var pos = doodle.transform.position;
        
        var limit = platformFactory.ahead;
        var inters = platformFactory.interst;
        
        platformFactory.CreatePlateform(pos, -1.2f, PlateformGenerator.SolidOnly);

      
        for (float i = (float)Math.Floor(pos.y) ; i < limit ;  i = i+inters)
        {
            if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
            {
                platformFactory.CreatePlateform(new Vector2(UnityEngine.Random.Range(-bound, bound), i));
            }
        }
    }


    private void CreatePlateform()
    {
        var highest = controller.GetHighest();
        
        var ahead = platformFactory.ahead;
        var doodleHt = (int)Math.Floor(doodle.transform.position.y * 2) / 2;


        if (doodleHt > lastGeneratedPlateformPoint)
        {
          
            /*if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
            {

                var x = UnityEngine.Random.Range(-3.7f, 3.7f);
                platformFactory.CreatePlateform(new Vector2(x, doodleHt + ahead));
                
            }*/
            

            var x = UnityEngine.Random.Range(-bound, bound);
            platformFactory.CreatePlateform(new Vector2(x, doodleHt + ahead));
           
            //Debug.Log("created at dd height : " + doodleHt + ", at height : " + doodleHt + ahead);

            lastGeneratedPlateformPoint = doodleHt;
                 
        }
    }

    private void CreateEnemy()
    {
        var highest = controller.GetHighest();
        var ahead = enemyFactory.ahead;

        var doodleHt = (int)Math.Floor(doodle.transform.position.y * 2) / 2;

        var dist_between_enemies = 10;

        if (doodleHt > lastGeneratedEnemyPoint + dist_between_enemies)
        {

            if (UnityEngine.Random.Range(0f, 1f) >= 0.9f)
            {
                enemyFactory.CreateEnemy(new Vector2(UnityEngine.Random.Range(-bound, bound), doodleHt + ahead));
            }

            lastGeneratedEnemyPoint = doodleHt;

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
        foreach (var obj in movableObjects)
        {
            obj.transform.Translate(new Vector2(0, difference));
        }
    }
}
