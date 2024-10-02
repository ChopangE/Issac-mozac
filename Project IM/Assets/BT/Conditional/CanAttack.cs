using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class CanAttack : Conditional
{
    public SharedTransform target;
    public float distance;
    public float fov;

    public override TaskStatus OnUpdate() {
        if (WithinSight(target.Value, fov)) {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

    public bool WithinSight(Transform targetTransform, float fieldOfViewAngle) {
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
        // return Vector2.Angle(direction, transform.forward) < fieldOfViewAngle && dist <= distance;
    }
}
