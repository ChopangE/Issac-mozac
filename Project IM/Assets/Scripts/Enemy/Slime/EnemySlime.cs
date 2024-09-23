using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBase
{
    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        if(CurHealth > 0 ) 
            Debug.Log("Hit");
            anim.Play("SlimeHit");

    }
}
