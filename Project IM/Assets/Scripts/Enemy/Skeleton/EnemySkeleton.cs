using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : EnemyBase
{
    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        if(CurHealth > 0 ) 
            anim.Play("SkeletonDead");
    }
}
