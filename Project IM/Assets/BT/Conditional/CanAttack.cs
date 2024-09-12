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
        Vector2 direction = targetTransform.position - transform.position;
        float dist = direction.magnitude;
        return Vector2.Angle(direction, transform.forward) < fieldOfViewAngle && dist <= distance;
    }
}
