using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Util;
using GameData;

public class Player : MonoBehaviour, IDamageable
{

    public Define.Classes classes { get { return (Define.Classes)Enum.Parse(typeof(Define.Classes), Managers.StatManager.Pd.Id); } }

    public float maxHealth { get {return Managers.StatManager.GetMaxHealth(); } }

    public float curHealth { get { return Managers.StatManager.Pd.Health; } set { Managers.StatManager.Pd.Health = value; } }
    
    public float atkSpeed { get { return Managers.StatManager.Pd.AtkSpeed; } set {  Managers.StatManager.Pd.AtkSpeed = value; } }

    public float damage {get { return Managers.StatManager.Pd.Damage; } set { Managers.StatManager.Pd.Damage = value; } }

    public float speed {get { return Managers.StatManager.Pd.Speed; } set { Managers.StatManager.Pd.Speed = value; } }

    public void GetDamage(float damage) {
        curHealth -= damage;
        Debug.Log(curHealth);
    }

    void Start()
    {
        Init();
    }

    void Init()
    {
        Managers.DataManager.SaveCurrentPlayerData();
        //DOVirtual.DelayedCall(3f, Managers.DataManager.LoadCurrentPlayerData).OnComplete(TetsDebug); //임시코드
        Managers.DataManager.LoadCurrentPlayerData();
    }

    void TetsDebug()
    {
        Debug.Log(classes + " " + curHealth + " " + damage + " "+atkSpeed + " " + speed);
    }
}
