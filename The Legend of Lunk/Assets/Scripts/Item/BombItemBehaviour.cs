using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItemBehaviour : ItemBehaviour
{
    [SerializeField] float TTL = 5f;
    float currentTime = 0f;
    bool Exploded = false;

    protected override void Start()
    {
        
    }
    private void Update()
    {
        Timer();
    }
    void Timer()
    {
        if (!Exploded)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= TTL)
            {
                Explode();
            }
        }
    }
    private void Explode()
    {
        Exploded = true;
        print("kaboom!");
        Destroy(this.gameObject);
    }
}
