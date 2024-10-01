using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using Util;
using GameData;



namespace Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        private PlayerData pd;
        protected PlayerControl playerControl;
        protected Animator anim;
        public Define.Classes classes
        {
            get { return (Define.Classes)Enum.Parse(typeof(Define.Classes), pd.Id); }
        }

        public float maxHealth
        {
            get { return Managers.StatManager.GetMaxHealth(); }
        }

        public Action<float> healthEvent;
        public float curHealth
        {
            get { return pd.Health; }
            set
            {
                pd.Health = value;
                healthEvent?.Invoke(pd.Health);
            }
        }

        public float atkSpeed
        {
            get { return pd.AtkSpeed; }
            set { pd.AtkSpeed = value; }
        }

        public float damage
        {
            get { return pd.Damage; }
            set { pd.Damage = value; }
        }
        
        public float speed
        {
            get { return pd.Speed; }
            set { pd.Speed = value; }
        }

        public virtual void GetDamage(float damage)
        {
            curHealth -= damage;
            playerControl.AttackEnd();
            anim.SetTrigger("Hit");
            
        }
        
        void Start()
        {
            Init();
        }
        
        void Init()
        {
            anim = GetComponent<Animator>();
            playerControl = GetComponent<PlayerControl>();
            pd = Managers.StatManager.Pd;
        }
        
        void TetsDebug()
        {
            Debug.Log(classes + " " + curHealth + " " + damage + " " + atkSpeed + " " + speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IItem item = other.GetComponent<IItem>();
            if (item == null) return;
            item.Use();
            
        }
    }
}
