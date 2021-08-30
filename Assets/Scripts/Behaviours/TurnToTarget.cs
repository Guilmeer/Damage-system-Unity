using UnityEngine;

public class TurnToTarget : Idle
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            Quaternion targetRotation = Quaternion.LookRotation(myBase.target.position - animator.transform.position);
            Quaternion actualRotation = Quaternion.Lerp(animator.transform.rotation, targetRotation, .015f);

            animator.transform.rotation = actualRotation;
    }
}
