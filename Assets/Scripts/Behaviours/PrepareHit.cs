using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareHit : Idle
{
    [SerializeField] float toHit;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        toHit = 0;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        toHit += Time.deltaTime;
        if (Vector3.Distance(animator.transform.position, myBase.target.position) > animator.GetFloat("HitDistance"))
        {
            animator.SetBool("OnHitRange", false);
        }
        if (toHit >= animator.GetFloat("WaitToHit")) animator.SetTrigger("Hit");

        Vector3 targetPoint = (myBase.target.position - animator.transform.position).normalized;
        Quaternion targetRotation =
        Quaternion.LookRotation(new Vector3(targetPoint.x, 0, targetPoint.z));
        Quaternion actualRotation = Quaternion.Lerp(animator.transform.rotation, targetRotation, 0.35f);

        animator.transform.rotation = actualRotation;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hit");
    }
}
