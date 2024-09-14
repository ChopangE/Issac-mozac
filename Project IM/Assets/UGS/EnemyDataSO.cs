using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NorskaLib.Spreadsheets;

namespace GameData
{
    [System.Serializable]
    public class EnemyData {
        public string Id;
        public float Health;
        public float Damage;
        public float Speed;
    }


    [System.Serializable]
    public class EnemyDataContainer
    {
        [SpreadsheetPage("EnemyData")]
        public List<EnemyData> enemyDatas;
    }
    [CreateAssetMenu(fileName = "EnemyDataSO", menuName = "EnemyDataSO")]
    public class EnemyDataSO : SpreadsheetsContainerBase {
        [SpreadsheetContent]
        [SerializeField] EnemyDataContainer dataContainer;
        public EnemyDataContainer DataContainer => dataContainer;
    }
}