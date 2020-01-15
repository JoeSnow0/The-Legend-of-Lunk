using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour
{
    public enum ItemPrefabIndex {Arrow, Bomb};
    public ItemPrefabIndex itemPrefabIndex;
    [SerializeField] Vector2 mInput;
    private Rigidbody2D mRigidbody;
    Animator mAnimator;
    public Health mHealth;
    public Vector3 mDirection = Vector2.down;
    float itemSpawnLocationOffset = 1f;
    SecondaryAbility mSecondaryAbility;
    [SerializeField] int itemNumber = 0;
    public ItemBehaviour[] itemPrefabs;

    //ItemStates
    public ItemState currentItemState;
    private BombItemState bombItemState;
    private ArrowItemState arrowItemState;
    //PlayerStates
    public PlayerState currentPlayerState;
    private NormalPlayerState normalPlayerState;
    private InvinciblePlayerState invinciblePlayerState;
    private AttackingPlayerState attackingPlayerState;
    


    private void Start()
    {
        
        mRigidbody = mRigidbody ?? GetComponent<Rigidbody2D>();
        mAnimator = mAnimator ?? GetComponent<Animator>();
        mHealth = mHealth ?? GetComponent<Health>();
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
            currentItemState.UseItem();
        }
    }
    void UpdateAnimation()
    {
        mAnimator.SetFloat("MoveX", mInput.x);
        mAnimator.SetFloat("MoveY", mInput.y);
    }
    
    void SetState(ItemState newState)
    {
        currentItemState.ExitState();
        currentItemState = newState;
        currentItemState.EnterState(this, itemPrefabs);
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
