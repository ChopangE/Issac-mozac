using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;

public class SlimeDie : Die
{
    public override void OnStart()
    {
        base.OnStart();
        anim.Play("SlimeDie");
    }
    
    
}
