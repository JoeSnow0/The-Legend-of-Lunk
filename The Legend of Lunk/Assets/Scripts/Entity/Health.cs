using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int mHealthMax;
    [SerializeField] int mCurrentHealth;

    public void AddHealth(int restore)
    {
        mCurrentHealth += restore;
        ClampHealth();
        AmIDead();
    }
    public void SubtractHealth(int damage)
    {
        mCurrentHealth -= damage;
        ClampHealth();
        AmIDead();
        print(gameObject + "'s health: " + mCurrentHealth + "/" + mHealthMax);
    }
    public void SetHealth(int setValue)
    {
        mCurrentHealth = setValue;
        ClampHealth();
        AmIDead();
    }
    public void SetMaxHealth(int setValue)
    {
        mHealthMax = setValue;
        ClampHealth();
        AmIDead();
    }
    public int GetHealth()
    {
        return mCurrentHealth;
    }
    private void AmIDead()
    {
        if(mCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void ClampHealth()
    {
        Mathf.Clamp(mCurrentHealth, 0, mHealthMax);
    }

}
