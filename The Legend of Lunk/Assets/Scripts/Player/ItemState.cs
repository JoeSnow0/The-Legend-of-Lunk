using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemState 
{
    void EnterState(PlayerController player, ItemBehaviour item);
    void UpdateState();
    void OnCollisionEnter2D();
    void ToBombState();
    void ToArrowState();
    void ExitState();

    void UseItem();
}
