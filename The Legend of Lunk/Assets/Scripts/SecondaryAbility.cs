using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAbility : MonoBehaviour
{
    ItemBehaviour[] ListOfPrefabAbilities;
    float currentTime;

    float cooldown = 0f;
    bool readyToUse;
    private void Update()
    {
        
    }
    void CooldownTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= cooldown)
        {
            readyToUse = true;
            currentTime = 0f;
        }

    }
}
