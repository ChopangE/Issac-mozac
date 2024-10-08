using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Enemy;
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
    }
    public override TaskStatus OnUpdate() {
        float dist = Vector2.SqrMagnitude(transform.position - target.Value.position);
        if (dist < 0.5f) {
            return TaskStatus.Success;
        }
        else if(dist > 5f) {
            return TaskStatus.Failure;
        }
        //spriteRenderer.flipX = transform.position.x > target.Value.position.x;
        //transform.localScale = target.Value.position.x > transform.position.x ? Vector3.one : new Vector3(-1, 1, 1);
        transform.position = Vector2.MoveTowards(transform.position,
            target.Value.position, speed * Time.deltaTime);
        anim.SetBool("isWalk",true);
        return TaskStatus.Running;
    }
}
