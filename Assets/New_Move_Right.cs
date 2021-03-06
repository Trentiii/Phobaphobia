using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Move_Right : StateMachineBehaviour
{
    public float speed;

    Transform moveSpots;
    Rigidbody2D rb;
    public bool there = false;

    public clownDamage script;
    public GameObject Clown;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        New_Move script2 = animator.GetBehaviour<New_Move>();
        script2.first = false;
        moveSpots = GameObject.FindGameObjectWithTag("movespot").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        GameObject Clown = GameObject.Find("Clown");
        script = Clown.GetComponent<clownDamage>();
        script.targetHealth = script.currentHealth -= 15;
        Clown_Shoot Shoot = animator.GetBehaviour<Clown_Shoot>();
        Shoot.fireRate = 0f;
        Clown_Shoot2 Shoot2 = animator.GetBehaviour<Clown_Shoot2>();
        Shoot2.fireRate = 1f;
        Clown_Shoot3 Shoot3 = animator.GetBehaviour<Clown_Shoot3>();
        Shoot3.fireRate = 2f;
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

        if (there == true)
        {
            animator.SetTrigger("Right");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Right");
    }

}
