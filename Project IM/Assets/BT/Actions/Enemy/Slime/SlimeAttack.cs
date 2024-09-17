using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using DG.Tweening;

public class SlimeAttack : AttackBT
{
    public SharedTransform target;
    
    public override void OnStart()
    {
        base.OnStart();
        anim.Play("SlimeAttack");
        transform.DOMove(target.Value.position, 0.2f, false).OnComplete(
            () =>
            {
                if (enemyBase.CurHealth > 0)
                {
                    anim.Play("Slime");
                }
                else
                {
                    anim.Play("SlimeDie");
                }
                CircleCollider2D collider = coll as CircleCollider2D;
                if (collider != null)
                {
                    Collider2D hit = Physics2D.OverlapCircle(transform.position, collider.radius, LayerMask.GetMask("Player"));
                    hit.GetComponent<IDamageable>().GetDamage(damage);
                }
            
            });
    }
    public override TaskStatus OnUpdate() {

        return TaskStatus.Success;
    }

    

}
