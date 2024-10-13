using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBonusInitializer : MonoBehaviour
{
    
    //public GameObject gameManager;
   
    
   
    
    void Start()
    {
        
        // bonusFactory = gameManager.GetComponent<BonusFactory>();
        var startup = GameObject.Find("GameManager"); //gameManager.GetComponent<GameManager>();    
        var manager = startup.GetComponent<GameManagerScript>();


        if (manager != null && manager.hasBonus())
        {
            var bonus = manager.selectBonus();
            bonus.transform.parent = this.transform;
            bonus.transform.localPosition = new Vector2(0, 1);

        }

    }
}
