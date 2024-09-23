using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;
using Util;

public class EnemyBase : MonoBehaviour, IDamageable
{
    protected Animator anim;
    public Define.EnemyType enemyType;
    public EnemyDataSO dataSO;
    private EnemyData data;
    public EnemyData Data => data;
    private float curHealth;
    public float CurHealth {get => curHealth; set { curHealth = value; } }

    void Awake()
    {
        Init();
    }

    void Init()
    {
        anim = GetComponent<Animator>();
        data = dataSO.DataContainer.enemyDatas[(int)enemyType];
    }

    private void OnEnable()
    {
        CurHealth = data.Health;
    }

    public virtual void GetDamage(float damage)
    {
        CurHealth -= damage;
    }

    void Die()
    {
        Managers.ResourceManager.Destroy(gameObject);
    }
}
