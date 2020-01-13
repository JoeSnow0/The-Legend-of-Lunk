using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyState : EnemyState
{
    private Transform mChaseTarget;
    [SerializeField] private float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mChaseTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, mChaseTarget.position,  Time.deltaTime);
        animator.transform.rotation = Quaternion.Euler(Vector3.RotateTowards(animator.transform.rotation.eulerAngles, mChaseTarget.rotation.eulerAngles, 0f, 0f));
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    void TargetIsNull(Animator animator)
    {
        if(mChaseTarget == null)
        {
            animator.SetBool("isFollowing", false);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
