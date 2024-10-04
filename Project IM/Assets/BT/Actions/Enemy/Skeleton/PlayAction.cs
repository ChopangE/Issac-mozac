using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class PlayAction : Conditional
{
   private Animator anim;
   public string animName;
   public override void OnAwake()
   {
      anim = GetComponent<Animator>();
   }

   public override void OnStart()
   {
      anim.SetTrigger(animName);
   }
}


