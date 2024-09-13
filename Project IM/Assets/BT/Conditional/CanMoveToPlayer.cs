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
        Vector2 direction = targetTransform.position - transform.position;
        float dist = direction.magnitude;
        return dist <= distance;
    }
}
