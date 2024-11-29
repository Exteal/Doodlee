using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour
{
    // Start is called before the first frame update

    public int ahead;
    public float interst = 0.5f;

    public GameObject greenPrefab;
    public GameObject bluePrefab;
    public GameObject brownPrefab;
   
    public GameObject plateforms;


    void Start()
    {
        ahead = 10;
    }

    public void CreatePlateform(Vector2 pos, float yoffset = 0)
    {
        GameObject prefab;
        var rd = Random.Range(0, 101);

        switch (rd)
        {
            case var _ when rd <= 10:
                prefab = brownPrefab;
                break;

            case var _ when rd <= 30:
                prefab = bluePrefab;
                break;

            default:
                prefab = greenPrefab;
                break;
        }

        Instantiate(prefab,  new Vector2(pos.x, pos.y + yoffset), Quaternion.identity, plateforms.transform);
    }
}
