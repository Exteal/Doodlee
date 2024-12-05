using System;
using UnityEngine;
using Random = System.Random;


public class EnemyFactory : MonoBehaviour
{
    // Start is called before the first frame update

    public int ahead;
    public GameObject[] prefabs;
    
    public GameObject obstacles;
    private Random random = new Random();


    void Start()
    {
        ahead = 30;
    }

    public void CreateEnemy(Vector2 pos, float yoffset = 0)
    {
        GameObject prefab = prefabs[random.Next(prefabs.Length)];
    
        Instantiate(prefab, new Vector2(pos.x, pos.y + yoffset), Quaternion.identity, obstacles.transform);
    }
}
