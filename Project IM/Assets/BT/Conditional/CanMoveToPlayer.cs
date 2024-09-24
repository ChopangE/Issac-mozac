using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveToPlayer : Conditional
{
    public SharedTransform target;
    public float distance;
    public override void OnAwake() {
        target.Value = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public override TaskStatus OnUpdate() {
        if (WithinSight(target.Value)) {
            return TaskStatus.Success;
        }
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
