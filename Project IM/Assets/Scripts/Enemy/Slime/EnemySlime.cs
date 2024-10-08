using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
  public class EnemySlime : EnemyBase
  {
      
      public override void GetDamage(float damage)
      {
          base.GetDamage(damage);
          if(CurHealth > 0 ) 
              anim.Play("SlimeHit");
      }
  }
  
}
