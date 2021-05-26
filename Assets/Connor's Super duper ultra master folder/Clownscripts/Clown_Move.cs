using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown_Move : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 1f;

    public float transition;
    public float goPoint;

    Transform player;
    Rigidbody2D rb;

    public clownDamage script;
    public GameObject Clown;
    public float currentTime;
    public bool first = true;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        GameObject Clown = GameObject.Find("Clown");
        script = Clown.GetComponent<clownDamage>();
        if (first == true)
        {
            goPoint = Time.time + transition;
            goPoint -= Time.time;
        }
        script.targetHealth = 0;
        if(script.damage == true)
        {
            goPoint += currentTime;
        }
        script.damage = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newpos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }

        if (Time.time > goPoint)
        {
            animator.SetTrigger("NextPhase");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("NextPhase");
    }
}
