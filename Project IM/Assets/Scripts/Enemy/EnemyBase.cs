using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;
using Util;

public class EnemyBase : MonoBehaviour
{
    public Define.EnemyType enemyType;
    public EnemyDataSO dataSO;
    private EnemyData data;
    public EnemyData Data => data;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        data = dataSO.DataContainer.enemyDatas[(int)enemyType];
    }
    

}
