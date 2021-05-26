﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Innefficient : StateMachineBehaviour
{
    private float currentTime;
    public float timeDiff;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        New_Move script = animator.GetBehaviour<New_Move>();
        timeDiff = currentTime - script.currentTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        New_Move script = animator.GetBehaviour<New_Move>();
        script.currentTime -= timeDiff;
    }
}
