using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapFactory : BonusFactory
{

    public GameObject prefab;

    public override GameObject ReturnBonus()
    {

        var bonus = Instantiate(prefab);
        bonus.tag = "bonus";

        return bonus;

    }

}
