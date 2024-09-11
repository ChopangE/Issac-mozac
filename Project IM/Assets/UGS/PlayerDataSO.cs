using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NorskaLib.Spreadsheets;

namespace GameData 
{
    [System.Serializable]
    public class PlayerData {
        public string Id;
        public float Health;
        public float Damage;
        public float Speed;
        public float AtkSpeed;
    }


    [System.Serializable]
    public class DataContainer
    {
        [SpreadsheetPage("PlayerData")]
        public List<PlayerData> playerDatas;
    }
    [CreateAssetMenu(fileName = "PlayerDataSO", menuName = "DataSO")]
    public class PlayerDataSO : SpreadsheetsContainerBase {
        [SpreadsheetContent]
        [SerializeField] DataContainer dataContainer;
        public DataContainer DataContainer => dataContainer;
    }
}
