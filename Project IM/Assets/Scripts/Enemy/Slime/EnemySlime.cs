using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBase
{
    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        anim.Play("SlimeHit");
    }
}
