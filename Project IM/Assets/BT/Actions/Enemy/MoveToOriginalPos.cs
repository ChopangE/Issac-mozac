using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveToOriginalPos : Action
{
    public Vector3 originalPos;
    public float speed;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public override void OnAwake() {
        originalPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    public override TaskStatus OnUpdate() {
        if ((transform.position - originalPos).magnitude < 0.01f)
        {
            anim.SetBool("isWalk",false);
            return TaskStatus.Failure;
        }
        anim.SetBool("isWalk",true);
        spriteRenderer.flipX = transform.position.x > originalPos.x;
        transform.position = Vector2.MoveTowards(transform.position,
            originalPos, speed * Time.deltaTime);
        return TaskStatus.Success;
    }

}
