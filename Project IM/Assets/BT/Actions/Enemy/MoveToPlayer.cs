using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Enemy;

public class MoveToPlayer : Action {
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
        if (dist < 3f) {
            Debug.Log("HI");
            return TaskStatus.Success;
        }
        else if(dist > 10f) {
            return TaskStatus.Failure;
        }
        
        spriteRenderer.flipX = transform.position.x > target.Value.position.x;
        transform.position = Vector2.MoveTowards(transform.position,
            target.Value.position, speed * Time.deltaTime);
        
        return TaskStatus.Running;
    }
}