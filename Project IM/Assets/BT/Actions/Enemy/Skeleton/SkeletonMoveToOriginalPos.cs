using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Enemy;
public class SkeletonMoveToOriginalPos : Action
{
    public Vector3 originalPos;
    private float speed;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public override void OnAwake() {
        originalPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        speed = GetComponent<EnemyBase>().Data.Speed;
    }
    
    public override TaskStatus OnUpdate() {
        if ((transform.position - originalPos).magnitude < 0.01f)
        {
            anim.SetBool("isWalk",false);
            return TaskStatus.Failure;
        }
        anim.SetBool("isWalk",true);
        //spriteRenderer.flipX = transform.position.x > originalPos.x;
        transform.position = Vector2.MoveTowards(transform.position,
            originalPos, speed * Time.deltaTime);
        return TaskStatus.Success;
    }
}
