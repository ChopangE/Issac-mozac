using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;
using Util;

public class EnemyBase : MonoBehaviour, IDamageable
{
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
        data = dataSO.DataContainer.enemyDatas[(int)enemyType];
        CurHealth = data.Health;
    }


    public void GetDamage(float damage)
    {
        CurHealth -= damage;
    }
}
