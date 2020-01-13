using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] protected Sprite mSprite;
    SpriteRenderer mSpriteRenderer;
    [SerializeField] protected float mSpeed;
    [HideInInspector] public Vector2 direction;
    [SerializeField] public bool mUnlocked = false;
    [SerializeField] public int mNumberOfUsesLeft = 0;
    //[SerializeField] float Cooldown = 0f;

    protected virtual void Start()
    {
        mSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        mSpriteRenderer.sprite = mSprite;
    }
    
    public bool IsAvailable()
    {
        if(mNumberOfUsesLeft > 0 && mUnlocked)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool HasUses()
    {
        if (mNumberOfUsesLeft >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
