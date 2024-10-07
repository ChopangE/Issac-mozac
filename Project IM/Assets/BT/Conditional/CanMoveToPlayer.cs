using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveToPlayer : Conditional
{
    public SharedTransform target;
    public float distance;
    private Animator anim;
    public override void OnAwake()
    {
        anim = GetComponent<Animator>();
    }

    public override TaskStatus OnUpdate() {
        if (WithinSight(target.Value))
        {
            anim.SetBool("isWalk", true);
            return TaskStatus.Success;
        }
        anim.SetBool("isWalk", false);
        anim.SetBool("isAttack", false);
        return TaskStatus.Failure;
    }
    public bool WithinSight(Transform targetTransform) {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, distance, LayerMask.GetMask("Player"));
        if (hit.Length > 0)
        {
            target.Value = hit[0].transform;
            float shortestDistance = (hit[0].transform.position - transform.position).magnitude;
            for (int i = 0; i < hit.Length; i++)
            {
                if ((hit[i].transform.position - transform.position).magnitude < shortestDistance)
                {
                    target.Value = hit[i].transform;
                }
            }

            return true;
        }

        return false;
        // Vector2 direction = targetTransform.position - transform.position;
        // float dist = direction.magnitude;
        // return dist <= distance;
    }
}
