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

    private float lastGeneratedDoodleHeight;
    
    private float lastGeneratedPlateformHeight;

    private float lastGeneratedEnemyHeight;

    private float bound = 2.6f;

    private int platformSeparation = 2;



    void Start()
    {

        controller = doodle.GetComponent<PlayerController>();
        platformFactory = GetComponent<PlatformFactory>();
        enemyFactory = GetComponent<EnemyFactory>();

        lastGeneratedDoodleHeight = doodle.transform.position.y;
        lastGeneratedEnemyHeight = doodle.transform.position.y;
        
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
      
        platformFactory.CreatePlateform(doodle.transform.position, -1.2f, PlateformGenerator.GreenOnly);
        generateManyPlatforms(doodle.transform.position, 0.4f);

    }


    private void CreatePlateform()
    {
        
        var highest = controller.GetHighest();
        var ahead = platformFactory.ahead;
        

        var doodleHeight = (int)Math.Floor(doodle.transform.position.y * 2) / 2;

        var noise = UnityEngine.Random.Range(-platformFactory.platformHeightNoise, platformFactory.platformHeightNoise);
        var nextHeight = (int)Math.Floor((lastGeneratedPlateformHeight + platformSeparation + noise) * 2) / 2;


        var multiple = UnityEngine.Random.Range(0f, 1f);


        if (doodleHeight > lastGeneratedDoodleHeight)
        {

            /*if (UnityEngine.Random.Range(0f, 1f) >= 0.5f)
            {

                var x = UnityEngine.Random.Range(-3.7f, 3.7f);
                platformFactory.CreatePlateform(new Vector2(x, doodleHt + ahead));
                
            }*/

            

            Debug.Log("Before create --------------------------------");
            Debug.Log("lastPlateformHeight : " + lastGeneratedPlateformHeight);
            Debug.Log("Calcul : last " + lastGeneratedPlateformHeight + " sep " + platformSeparation + " noise " + noise);
            Debug.Log("nextHeight : " + nextHeight);

            if (multiple > 0.9f)
            {
                generateManyPlatforms(new Vector2(UnityEngine.Random.Range(-bound, bound), nextHeight), UnityEngine.Random.Range(0.3f, 0.8f));
            }
            else
            {
                platformFactory.CreatePlateform(new Vector2(UnityEngine.Random.Range(-bound, bound), nextHeight));
            }
            
            lastGeneratedPlateformHeight = nextHeight;
            lastGeneratedDoodleHeight = doodleHeight;

        }
    }

    private void CreateEnemy()
    {
        var highest = controller.GetHighest();
        var ahead = enemyFactory.ahead;

        var doodleHt = (int)Math.Floor(doodle.transform.position.y * 2) / 2;

        var dist_between_enemies = 10;

        if (doodleHt > lastGeneratedEnemyHeight + dist_between_enemies)
        {

            if (UnityEngine.Random.Range(0f, 1f) >= 0.1f)
            {
                enemyFactory.CreateEnemy(new Vector2(UnityEngine.Random.Range(-bound, bound), doodleHt + ahead));
            }

            lastGeneratedEnemyHeight = doodleHt;

        }

    }


    private void generateManyPlatforms(Vector2 startingPosition, float density)
    {
         
        for (float i = (float)Math.Floor(startingPosition.y); i <= platformFactory.ahead; i = i + platformFactory.interst)
        {
            if (UnityEngine.Random.Range(0f, 1f) >= density)
            {
                platformFactory.CreatePlateform(new Vector2(UnityEngine.Random.Range(-bound, bound), i));
                lastGeneratedPlateformHeight = i;
            }
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
