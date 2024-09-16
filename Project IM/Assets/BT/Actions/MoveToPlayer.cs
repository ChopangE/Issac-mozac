using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class MoveToPlayer : Action {
    float speed;
    public SharedTransform target;
    SpriteRenderer spriteRenderer;
    public override void OnStart()
    {
        speed = gameObject.GetComponent<EnemyBase>().Data.Speed;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public override TaskStatus OnUpdate() {
        float dist = Vector2.SqrMagnitude(transform.position - target.Value.position);
        if (dist < 3f) {
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