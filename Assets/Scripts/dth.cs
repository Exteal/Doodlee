using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dth : StateMachineBehaviour
{
    public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("timesPlayed", animator.GetInteger("timesPlayed") - 1);
    }

    

}
