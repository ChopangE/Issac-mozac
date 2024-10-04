using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : AttackBT
{
    public override void OnStart()
    {
        Debug.Log("SkeletonAttack!");
        anim.SetTrigger("Attack");
    }
}
