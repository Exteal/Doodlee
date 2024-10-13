using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spring : Bonus
{

    public Spring() {
        //pathToPrefab = "Prefabs/Spring";
        modifier = 1.3f;
        isOneShot = false;
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
