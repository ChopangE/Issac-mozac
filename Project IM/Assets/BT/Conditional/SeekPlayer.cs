using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SeekPlayer : Conditional
{
    public string targetTag;
    public SharedTransform target;
    public float fov;
    Transform target_;

    public override void OnAwake() {
        target_ = GameObject.FindGameObjectWithTag(targetTag).transform;
        target.Value = target_;
    }

    public override TaskStatus OnUpdate() {
        if (WithinSight(target_, fov)) {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

    public bool WithinSight(Transform targetTransform, float fieldOfViewAngle) {
        Vector2 direction = targetTransform.position - transform.position;
        return Vector2.Angle(direction, transform.forward) < fieldOfViewAngle;
    }
}
