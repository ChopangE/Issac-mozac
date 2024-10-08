using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class FacingToPlayer : Action
{
    public SharedTransform target;
    public override void OnAwake()
    {
        target.Value = GameObject.FindObjectOfType<Player.Player>().transform;
    }

    public override void OnStart()
    {
        Vector3 turnLeftDir = new Vector3(-1, 1, 1);
        transform.localScale = transform.position.x > target.Value.position.x ? turnLeftDir : Vector3.one;
    }
}
