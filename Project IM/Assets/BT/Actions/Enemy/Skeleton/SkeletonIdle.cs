using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SkeletonIdle : Action
{
    private Animator anim;
    public override void OnAwake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public override void OnStart()
    {
        anim.Play("Idle");
    }

    
}
