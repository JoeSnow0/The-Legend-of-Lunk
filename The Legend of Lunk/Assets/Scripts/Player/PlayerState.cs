﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    void EnterState();
    void UpdateState();
    void OnCollisionEnter2D();
    void ToInvincibleState();
    void ToNormalState();
    void ToAttackingState();
    void ExitState();
}
