using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class EnemyAnimEventController : MonoBehaviour
    {
        protected Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
    }
}

