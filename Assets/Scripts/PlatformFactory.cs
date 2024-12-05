using UnityEngine;

public enum PlateformGenerator
{
    SolidOnly,
    All,
    GreenOnly
}

public class PlatformFactory : MonoBehaviour
{
    public int ahead;
    public float interst = 0.5f;

    public GameObject greenPrefab;
    public GameObject bluePrefab;
    public GameObject brownPrefab;
   
    public GameObject plateforms;
    
    public float platformHeightNoise;
    void Start()
    {
        ahead = 25;
        platformHeightNoise = 0.5f;
        
    }

    private GameObject SolidOnlyGeneration()
    {
        var rd = Random.Range(0, 101);
        if (rd <= 25)
        {
            return bluePrefab;     
        }
        return greenPrefab;
    }

    private GameObject AllPlateformsGeneration()
    {
        var rd = Random.Range(0, 101);

        switch (rd)
        {
            case var _ when rd <= 10:
                return brownPrefab;

            case var _ when rd <= 30:
                return bluePrefab;

            default:
                return greenPrefab;
        }
    }

    public void CreatePlateform(Vector2 pos, float yoffset = 0, PlateformGenerator generator = PlateformGenerator.All)
    {
        GameObject prefab = null;
        
        switch (generator)
        {
            case PlateformGenerator.SolidOnly:
                prefab = SolidOnlyGeneration();
                break;
            
            case PlateformGenerator.All:
                prefab = AllPlateformsGeneration();
                break;
            
            case PlateformGenerator.GreenOnly:
                prefab = greenPrefab;
                break;

        }
        
        Instantiate(prefab,  new Vector2(pos.x, pos.y + yoffset), Quaternion.identity, plateforms.transform);
    }
}


