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

        public void GetDamage(float damage)
        {
            curHealth -= damage;
            Debug.Log(curHealth);
        }

        void Start()
        {
            Init();
        }
        
        void Init()
        {
            //DOVirtual.DelayedCall(3f, Managers.DataManager.LoadCurrentPlayerData).OnComplete(TetsDebug); //임시코드
            Managers.DataManager.LoadCurrentPlayerData();
            pd = Managers.StatManager.Pd;
        }

        void TetsDebug()
        {
            Debug.Log(classes + " " + curHealth + " " + damage + " " + atkSpeed + " " + speed);
        }


    }
}
