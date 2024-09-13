using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using DG.Tweening;

public class SlimeAttack : AttackBT
{
    public SharedTransform target;
    Transform original;
    public override void OnStart() {
        original = transform;
        anim.Play("SlimeAttack");
        transform.DOMove(target.Value.position, 0.3f, false).OnComplete(
            () => { anim.Play("Slime"); 
        });
    }
    public override TaskStatus OnUpdate() {

        return TaskStatus.Success;
    }


}
