using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItemState : ItemState
{
    private ItemBehaviour itemPrefab;
    int ammo;
    private PlayerController mPlayerController;
    public void EnterState(PlayerController player, ItemBehaviour item)
    {
        
    }

    public void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public void OnCollisionEnter2D()
    {
        throw new System.NotImplementedException();
    }

    public void ToArrowState()
    {
        throw new System.NotImplementedException();
    }

    public void ToBombState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public void UseItem()
    {
        GameObject.Instantiate(itemPrefab);
    }
}
