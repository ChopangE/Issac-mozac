using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private float damage_;
    protected float damage { get => damage_; set => damage_ = value; }
    protected Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    public virtual void OnEnable()
    {
    }
    
    
    public void InitDamage(float damage)
    {
        this.damage = damage;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null || other.CompareTag("Player")) return;
        damageable.GetDamage(damage);
    }
}
