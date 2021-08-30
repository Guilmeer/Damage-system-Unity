using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : StateMachineBehaviour
{
    [SerializeField] protected Enemy myBase;
    [SerializeField] protected NavMeshAgent agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        myBase = animator.GetComponent<Enemy>();
        agent = animator.GetComponent<NavMeshAgent>();
        agent.stoppingDistance = animator.GetFloat("HitDistance");
        agent.speed = myBase.speed;
        agent.isStopped = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.transform.position, myBase.target.position) <= animator.GetFloat("AggroRange"))
        {
            animator.SetTrigger("AggroEnter");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AggroEnter");
    }
}
