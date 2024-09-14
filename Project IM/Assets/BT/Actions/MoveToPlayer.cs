using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class MoveToPlayer : Action {
    float speed;
    public SharedTransform target;

    public override void OnStart()
    {
        speed = gameObject.GetComponent<EnemyBase>().Data.Speed;
    }
    public override TaskStatus OnUpdate() {
        float dist = Vector2.SqrMagnitude(transform.position - target.Value.position);
        if (dist < 3f) {
            return TaskStatus.Success;
        }
        else if(dist > 10f) {
            return TaskStatus.Failure;
        }
        
        transform.position = Vector2.MoveTowards(transform.position,
            target.Value.position, speed * Time.deltaTime);
        return TaskStatus.Running;
    }
}