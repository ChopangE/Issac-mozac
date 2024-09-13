using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public Define.Classes classes =  Define.Classes.None;

    float maxHealth_;
    public float maxHealth => maxHealth_;

    float curHealth_;
    public float curHealth { get { return curHealth_; } set { curHealth_ = value; } }


    public void GetDamage(float damage) {
        curHealth -= damage;
    }
}
