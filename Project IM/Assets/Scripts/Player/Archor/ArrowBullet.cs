using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ArrowBullet : BulletBase
{
    private float speed = 5f;
    private Vector3 dir;
    Tween tween;
    public override void OnEnable()
    {
        base.OnEnable();
        tween.Kill();
        rb.velocity = Vector2.zero;
        tween = DOVirtual.DelayedCall(1f, () =>
        {
            if (gameObject.activeSelf)
            {
                Managers.ResourceManager.Destroy(gameObject);
            }
        });
    }
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null || other.CompareTag("Player")) return;
        Disaaper();
    }

    void Disaaper()
    {
        Managers.ResourceManager.Destroy(gameObject);
    }
}
