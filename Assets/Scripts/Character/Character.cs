using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float maxHp = 100.0f;
    protected float hp;

    [SerializeField]
    protected float movementSpeed = 8.0f;

    private bool isDead;

    protected virtual void Awake()
    {
        hp = maxHp;
        isDead = false;
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual void TakeDamage(float damage)
    {
        hp -= damage;
        if (!isDead && hp <= 0.0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        isDead = true;
    }
}
