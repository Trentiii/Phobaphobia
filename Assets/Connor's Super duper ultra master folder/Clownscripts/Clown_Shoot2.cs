using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown_Shoot2 : StateMachineBehaviour
{
    public Transform firePoint;
    public GameObject boolet;
    public float fireRate;
    public float cooldownTime;
    public Clown_Move_Right script;
    public float enterTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        firePoint = GameObject.FindGameObjectWithTag("firepoint2").transform;
        enterTime = Time.time;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((Time.time - enterTime) > fireRate)
        {
            shoot();
            fireRate = (Time.time - enterTime) + cooldownTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    void shoot()
    {
        Instantiate(boolet, firePoint.position, firePoint.rotation);
    }
}
