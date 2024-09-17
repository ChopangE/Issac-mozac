using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ArrowBullet : BulletBase
{
    private float speed = 5f;
    private Vector3 dir;
    void OnEnable()
    {
        Init();
        Shoot();
    }

    void Init()
    {
        transform.position = player.transform.position;
        dir = playerControl.direction.magnitude > 0 ? playerControl.direction : playerControl.prevDirection;
        transform.rotation = Quaternion.FromToRotation(Vector3.right,dir);
    }
    
    void Shoot()
    {
        rb.AddForce(speed * dir, ForceMode2D.Impulse);
        DOVirtual.DelayedCall(1f, () => { Managers.ResourceManager.Destroy(gameObject);});
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null || other.CompareTag("Player")) return;
        Managers.ResourceManager.Destroy(gameObject);
    }

    void Dissaper()
    {
        Managers.ResourceManager.Destroy(gameObject);
    }
}
