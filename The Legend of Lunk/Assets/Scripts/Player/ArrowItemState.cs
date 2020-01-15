using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItemState : ItemState
{
    private PlayerController mPlayer;
    ItemBehaviour itemPrefab;
    private int CurrentAmmo;
    private int MaxAmmo;
    public void EnterState(PlayerController player, ItemBehaviour item)
    {
        itemPrefab = item;
        mPlayer = player;
    }

    public void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public void OnCollisionEnter2D()
    {
        
    }

    public void ToArrowState()
    {
        //Nothing, same state
    }

    public void ToBombState()
    {
        
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        
    }

    public void UseItem()
    {
        GameObject.Instantiate(itemPrefab);
    }
}
