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

        var startup = GameObject.Find("GameManager");
        var manager = startup.GetComponent<GameManagerScript>();

        springFactory = startup.GetComponent<SpringFactory>();
        capFactory = startup.GetComponent<CapFactory>();


        if (manager != null && hasBonus())
        {
            var bonus = selectBonus();
            bonus.transform.parent = this.transform;
            bonus.transform.localPosition = new Vector2(0, 1);

        }

    }
    public bool hasBonus()
    {
        return UnityEngine.Random.Range(0f, 1f) >= 0.9f;
    }

    public GameObject selectBonus()
    {
        var rd = UnityEngine.Random.Range(0f, 1f);

        BonusFactory factory = null;

        switch(rd)
        {
            case var _ when rd >= 0.5f:

                factory = springFactory;
                break;

            case var _ when rd <= 0.5f:
                factory = capFactory;
                break;
            
            default:
                factory = springFactory;
                break;
        }

        return factory.ReturnBonus();
    }
    
}
