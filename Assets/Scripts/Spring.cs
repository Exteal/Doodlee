using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spring : Bonus
{

    public Spring() {
        isOneShot = false;
        topUseOnly = true;
    }

    public override RuntimeAnimatorController EquipAnimation()
    {
        return null;
    }

    public override bool HasEquipAnimation()
    {
        return false;
    }

}
