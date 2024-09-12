using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class MoveToPlayer : Action {
    // 오브젝트의 속도
    public float speed = 0;
    // 오브젝트가 이동해야할 위치 정보가 담긴 Transform
    public SharedTransform target;
    public override TaskStatus OnUpdate() {
        // target에 도달하면 성공의 태스크 상태를 반환합니다.
        if (Vector2.SqrMagnitude(transform.position - target.Value.position) < 0.1f) {
            return TaskStatus.Success;
        }
        // 아직 목표에 도달하지 못했으므로 계속 이동합니다.
        transform.position = Vector2.MoveTowards(transform.position,
            target.Value.position, speed * Time.deltaTime);
        return TaskStatus.Running;
    }
}