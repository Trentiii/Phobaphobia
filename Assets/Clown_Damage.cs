using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown_Damage : StateMachineBehaviour
{
    public clownDamage script;
    public GameObject Clown;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject Clown = GameObject.Find("Clown");
        script = Clown.GetComponent<clownDamage>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (script.damage == true)
        {
            animator.SetTrigger("LastPhase");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("LastPhase");
    }
}
