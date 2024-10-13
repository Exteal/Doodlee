using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : Bonus
{
    
    public Cap() 
    {
        //pathToPrefab = "Prefabs/Cap";
        modifier = 1.5f;
        isOneShot = true;
    }
    public override RuntimeAnimatorController EquipAnimation()
    {
       return Resources.Load<RuntimeAnimatorController>("Animations/EquipAnimations/CapAnimator");
    }

    public override bool HasEquipAnimation()
    {
        return true ;
    }

}
