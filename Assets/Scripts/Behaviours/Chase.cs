using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Idle
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        agent.isStopped = false;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(myBase.target.position);

        if (Vector3.Distance(animator.transform.position, myBase.target.position) <= animator.GetFloat("HitDistance"))
        {
            animator.SetBool("OnHitRange", true);
        }
        else
        {
            animator.SetBool("OnHitRange", false);
        }

        if (Vector3.Distance(animator.transform.position, myBase.target.position) > animator.GetFloat("AggroRange"))
        {
            animator.SetTrigger("AggroLeft");
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AggroLeft");
    }
}
