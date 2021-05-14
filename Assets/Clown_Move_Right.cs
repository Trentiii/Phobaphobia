using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown_Move_Right : StateMachineBehaviour
{
    public float speed = 2.5f;

    Transform moveSpots;
    Rigidbody2D rb;
    public bool there = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveSpots = GameObject.FindGameObjectWithTag("movespot").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (there == false)
        {
            Vector2 target = new Vector2(moveSpots.position.x, rb.position.y);
            Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newpos);
        }
        if (rb.transform.position == moveSpots.position)
        {
            there = true;
        }
        else
        {
            there = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
