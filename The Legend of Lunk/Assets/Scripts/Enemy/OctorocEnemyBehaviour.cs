using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctorocEnemyBehaviour : EnemyBehaviour
{
    Animator mAnimator;
    
    PatrolEnemyState patrolEnemyState;
    ChaseEnemyState chaseEnemyState;
    [SerializeField] private float mPatrolMovementMultiplier = 1f;
    [SerializeField] private float mChaseMovementMultiplier = 2f;
    string animVarNameFollow = "isFollowing";
    string animVarNamePatrol = "isPatrolling";

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        patrolEnemyState = mAnimator.GetBehaviour<PatrolEnemyState>();
        chaseEnemyState = mAnimator.GetBehaviour<ChaseEnemyState>();
        patrolEnemyState.mMoveSpeed = moveSpeed * mPatrolMovementMultiplier;
        chaseEnemyState.mMoveSpeed = moveSpeed * mChaseMovementMultiplier;
        mAnimator.SetBool(animVarNameFollow, false);
        mAnimator.SetBool(animVarNamePatrol, true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mAnimator.SetBool(animVarNameFollow, true);
            mAnimator.SetBool(animVarNamePatrol, false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mAnimator.SetBool(animVarNameFollow, false);
            mAnimator.SetBool(animVarNamePatrol, true);
        }
    }
    
}
