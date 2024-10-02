using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SkeletonDie : Die
{
    public override void OnStart()
    {
        base.OnStart();
        anim.Play("SkeletonDead");
        DOVirtual.DelayedCall(3f, () =>
            {
                Managers.ResourceManager.Destroy(gameObject);
                
                
            }
        );
    }
}
