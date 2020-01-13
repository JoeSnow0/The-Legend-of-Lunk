using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowArrowItemBehaviour : ItemBehaviour
{
    [SerializeField] float TTL = 1f;
    float currentTime = 0f;
    bool isDead = false;
    protected override void Start()
    {
    }
    private void Update()
    {
        Timer();
        MoveArrow();
    }
    private void MoveArrow()
    {
        transform.Translate(direction * mSpeed);
    }
    void Timer()
    {
        if (!isDead)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= TTL)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Destroy(transform.gameObject);
    }

}
