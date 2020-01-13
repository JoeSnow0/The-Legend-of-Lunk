using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 0.5f;
    protected Health mHealth;

    private void Awake()
    {
        mHealth = GetComponent<Health>();
    }
    private void Start()
    {
        mHealth = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().SubtractHealth(1);
        }
        if(collision.gameObject.tag == "FriendlyProjectile")
        {
            mHealth.SubtractHealth(1);
        }
    }
}
