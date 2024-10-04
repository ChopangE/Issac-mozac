using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SkeletonMoveToOriginalPos : Action
{
    public Vector3 originalPos;
    public float speed;
    private SpriteRenderer spriteRenderer;
    public override void OnAwake() {
        originalPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override TaskStatus OnUpdate() {
        if ((transform.position - originalPos).magnitude < 0.01f) return TaskStatus.Success;
        spriteRenderer.flipX = transform.position.x > originalPos.x;

        transform.position = Vector2.MoveTowards(transform.position,
            originalPos, speed * Time.deltaTime);
        return TaskStatus.Failure;
    }
}
