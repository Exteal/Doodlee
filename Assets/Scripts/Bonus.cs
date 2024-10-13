using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{


    public float modifier;   
    public bool isOneShot { get; set; }
    public abstract bool HasEquipAnimation();

    public abstract RuntimeAnimatorController EquipAnimation();

    public float ComputeJumpPower()
    {
        return modifier;
    }
}
