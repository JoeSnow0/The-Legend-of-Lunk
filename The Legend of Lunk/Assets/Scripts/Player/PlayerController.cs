using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 mInput;
    private Rigidbody2D mRigidbody;
    Animator mAnimator;
    public Health mHealth;
    private Vector3 mDirection = Vector2.down;
    float itemSpawnLocationOffset = 1f;
    SecondaryAbility mSecondaryAbility;
    //Vector3 itemSpawnLocationOffset = Vector3.zero;
    [SerializeField] int itemNumber = 0;
    [SerializeField] ItemBehaviour[] itemPrefabs;

    private void Start()
    {
        
        mRigidbody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mHealth = GetComponent<Health>();
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
            mDirection = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            mInput.y += 1;
            mDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            mInput.x -= 1;
            mDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            mInput.x += 1;
            mDirection = Vector2.right;
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            UseItem();
        }
    }
    void UpdateAnimation()
    {
        mAnimator.SetFloat("MoveX", mInput.x);
        mAnimator.SetFloat("MoveY", mInput.y);
    }
    void UseItem()
    {
        if (itemPrefabs[itemNumber].IsAvailable())
        {
            ItemBehaviour item = Instantiate(itemPrefabs[itemNumber], transform);
            item.transform.position += itemSpawnLocationOffset * mDirection;
            item.transform.parent = null;
            item.direction = mDirection;
            if(itemPrefabs[itemNumber].HasUses())
            {
                SubtractItemUses(itemPrefabs[itemNumber]);
            }
        }
        
    }
    void SetItemUses(ItemBehaviour itemPrefab, int newAmount)
    {
        itemPrefab.mNumberOfUsesLeft = newAmount;
    }
    void SubtractItemUses(ItemBehaviour itemPrefab)
    {
        itemPrefab.mNumberOfUsesLeft --;
    }
    void AddItemUses(ItemBehaviour itemPrefab)
    {
        itemPrefab.mNumberOfUsesLeft ++;
    }
    void UseAttack()
    {

    }
}
