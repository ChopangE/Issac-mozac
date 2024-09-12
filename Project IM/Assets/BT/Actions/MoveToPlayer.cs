using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
public class MoveToPlayer : Action {
    // ������Ʈ�� �ӵ�
    public float speed = 0;
    // ������Ʈ�� �̵��ؾ��� ��ġ ������ ��� Transform
    public SharedTransform target;
    public override TaskStatus OnUpdate() {
        // target�� �����ϸ� ������ �½�ũ ���¸� ��ȯ�մϴ�.
        if (Vector2.SqrMagnitude(transform.position - target.Value.position) < 0.1f) {
            return TaskStatus.Success;
        }
        // ���� ��ǥ�� �������� �������Ƿ� ��� �̵��մϴ�.
        transform.position = Vector2.MoveTowards(transform.position,
            target.Value.position, speed * Time.deltaTime);
        return TaskStatus.Running;
    }
}