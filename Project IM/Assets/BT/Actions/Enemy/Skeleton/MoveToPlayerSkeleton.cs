using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MoveToPlayerSkeleton : Action
{
    float speed;
    public SharedTransform target;
    SpriteRenderer spriteRenderer;
    protected Animator anim;
    public override void OnStart()
    {
        speed = gameObject.GetComponent<EnemyBase>().Data.Speed;
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        anim.SetTrigger("Walk");
    }
    public override TaskStatus OnUpdate() {
        float dist = Vector2.SqrMagnitude(transform.position - target.Value.position);
        if (dist < 1f) {
            return TaskStatus.Success;
        }
        else if(dist > 5f) {
            return TaskStatus.Failure;
        }
        spriteRenderer.flipX = transform.position.x > target.Value.position.x;
        transform.position = Vector2.MoveTowards(transform.position,
            target.Value.position, speed * Time.deltaTime);
        
        return TaskStatus.Running;
    }
}
