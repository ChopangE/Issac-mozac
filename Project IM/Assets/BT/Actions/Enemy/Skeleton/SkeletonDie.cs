using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDie : Die
{
    public override void OnStart()
    {
        base.OnStart();
        anim.Play("SkeletonDead");
    }
}
