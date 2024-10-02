using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveToOriginalPos : Action
{
    public Vector3 originalPos;
    public float speed;
    public override void OnStart() {
        originalPos = transform.position;
    }

    public override TaskStatus OnUpdate() {
        if ((transform.position - originalPos).magnitude < 0.01f) return TaskStatus.Success;
        transform.position = Vector2.MoveTowards(transform.position,
            originalPos, speed * Time.deltaTime);
        return TaskStatus.Running;
    }

}
