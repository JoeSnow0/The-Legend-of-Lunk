using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 mInput;
    private Rigidbody2D mRigidbody;
    Animator mAnimator;

    private void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        if (mRigidbody == null)
        {
            mRigidbody = gameObject.AddComponent<Rigidbody2D>();
        }
    }
    
    private void FixedUpdate()
    {
        GetInput();
        Move();
        UpdateAnimation();
    }
    private void Update()
    {
        
    }
    private void Move()
    {
        Vector2 newPosition = Vector2.zero;
        float speedModifier = 0.15f;
        newPosition.x = speedModifier * mInput.x + transform.position.x;
        newPosition.y = speedModifier * mInput.y + transform.position.y;
        mRigidbody.MovePosition(newPosition);
    }
    private void GetInput()
    {
        mInput = Vector2.zero;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mInput.y -= 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mInput.y += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mInput.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mInput.x += 1;
        }
    }
    void UpdateAnimation()
    {
        mAnimator.SetFloat("MoveX", mInput.x);
        mAnimator.SetFloat("MoveY", mInput.y);
    }
}
