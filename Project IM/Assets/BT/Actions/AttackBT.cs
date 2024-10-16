using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBT : Action
{
    protected Animator anim;
    protected Collider2D coll;
    protected float damage;
    public override void OnAwake() {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    public override void OnStart()
    {
        damage = gameObject.GetComponent<EnemyBase>().Data.Damage;
    }
}
