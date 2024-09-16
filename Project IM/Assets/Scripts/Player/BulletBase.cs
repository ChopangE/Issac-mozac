using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private float damage_;
    protected float damage { get => damage_; set => damage_ = value; }
    protected Rigidbody2D rb;
    protected Player.Player player;
    protected PlayerControl playerControl;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player.Player>();
        playerControl = FindObjectOfType<PlayerControl>();
        
    }
    // public void Init(Player.Player player, PlayerControl playerControl)
    // {
    //     this.player = player;
    //     this.playerControl = playerControl;
    // }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null || other.CompareTag("Player")) return;
        damageable.GetDamage(damage);
        Debug.Log("Hit");
    }
}
