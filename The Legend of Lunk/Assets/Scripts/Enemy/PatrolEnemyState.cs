using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyState : EnemyState
{
    private Transform mPatrolTarget;
    private PatrolPoints[] mPatrolPaths;
    private PatrolPoints mCurrentPath;
    int pointIndex = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetPath();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, mPatrolTarget.position, mMoveSpeed * Time.deltaTime);
        animator.transform.rotation = Quaternion.Euler(Vector3.RotateTowards(animator.transform.rotation.eulerAngles, mPatrolTarget.rotation.eulerAngles, mMoveSpeed * Time.deltaTime, 0f));
        CheckIfAtDestination(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    void CheckIfAtDestination(Animator animator)
    {
        if(animator.transform.position == mPatrolTarget.position)
        {
            MoveToNextPoint();
        }
    }
    void MoveToNextPoint()
    {
        pointIndex += 1;
        mPatrolTarget = mCurrentPath.points[pointIndex % mCurrentPath.points.Count];
    }
    void SetPath()
    {
        mPatrolPaths = FindObjectsOfType<PatrolPoints>();
        mPatrolPaths.Initialize();
        if(mPatrolPaths == null)
        {
            mPatrolTarget.position = Vector3.zero;
            Debug.LogError("No Paths available for: " + this);
        }
        else
        {
            mCurrentPath = mPatrolPaths[Random.Range(0, mPatrolPaths.Length)];
            mPatrolTarget = mCurrentPath.points[Random.Range(0, mPatrolPaths.Length)];
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
