using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBonusInitializer : MonoBehaviour
{
    private BonusFactory springFactory;
    private BonusFactory capFactory;

    void Start()
    {

        springFactory = GetComponent<SpringFactory>();
        capFactory = GetComponent<CapFactory>();

        var startup = GameObject.Find("GameManager"); //gameManager.GetComponent<GameManager>();    
        var manager = startup.GetComponent<GameManagerScript>();


        if (manager != null && hasBonus())
        {
            var bonus = selectBonus();
            bonus.transform.parent = this.transform;
            bonus.transform.localPosition = new Vector2(0, 1);

        }

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
                factory = springFactory;
                break;
        }

        return factory.ReturnBonus();
    }
    
}
