using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringFactory : BonusFactory
{

    public GameObject prefab;

    public override GameObject ReturnBonus()
    {
        //Debug.Log("iiiii " + (prefab == null ? "nul" : "nop"));
        var bonus = Instantiate(prefab);
        bonus.tag = "bonus";

        //Debug.LogError(bonus);
       
        return bonus;

    }

}