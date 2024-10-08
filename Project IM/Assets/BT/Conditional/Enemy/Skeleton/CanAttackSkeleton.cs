using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CanAttackSkeleton : Conditional
{
    public SharedTransform target;
    public float distance;
    public float fov;
    private Animator anim;

    public override void OnAwake()
    {
        anim = GetComponent<Animator>();
        target.Value = GameObject.FindObjectOfType<Player.Player>().transform;
    }

    public override void OnStart()
    {
        anim.SetBool("isAttack",false);
    }

    
    public override TaskStatus OnUpdate() {
        if (WithinSight(target.Value, fov)) {
            anim.SetBool("isAttack", true);
            anim.SetBool("isWalk",false);
            return TaskStatus.Success;
        }
        anim.SetBool("isAttack", false);
        return TaskStatus.Failure;
    }

    public bool WithinSight(Transform targetTransform, float fieldOfViewAngle) {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, distance, LayerMask.GetMask("Player"));
        if (hit.Length > 0)
        {
            target.Value = hit[0].transform;
            float shortestDistance = (hit[0].transform.position - transform.position).magnitude;
            for (int i = 0; i < hit.Length; i++)
            {
                if ((hit[i].transform.position - transform.position).magnitude < shortestDistance)
                {
                    target.Value = hit[i].transform;
                }
            }

            return true;
        }

        return false;
        // Vector2 direction = targetTransform.position - transform.position;
        // float dist = direction.magnitude;
        // return Vector2.Angle(direction, transform.forward) < fieldOfViewAngle && dist <= distance;
    }
}
