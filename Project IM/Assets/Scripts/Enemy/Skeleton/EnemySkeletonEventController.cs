using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
   public class EnemySkeletonEventController : EnemyAnimEventController
   {
       private Transform attackRange;
       private EnemyBase enemyBase;
       [SerializeField]
       private Vector3 offset;

       [SerializeField]
       private LayerMask layerMask;
       
       [SerializeField]
       private Vector2 boxSize;

       private void OnEnable()
       {
           Init();
       }

       void Init()
       {
           enemyBase = GetComponent<EnemyBase>();
           attackRange = transform.GetChild(0);
       }

       public void OnAttack()
       {
           Collider2D coll = Physics2D.OverlapBox(attackRange.position, boxSize, 0, layerMask);
           if (coll != null)
           {
               IDamageable damageable = coll.GetComponent<IDamageable>();
               if (damageable != null)
               {
                   damageable.GetDamage(enemyBase.Data.Damage);
               }
           }
       }

       
   } 
}

