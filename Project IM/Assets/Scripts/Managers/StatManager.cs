using System.Collections;
using System.Collections.Generic;
using GameData;
using Interface;
using UnityEngine;
using Util;

public class StatManager : IManager
{
    //<summary>
    //statManager에 있는 정보를 player Script에서 참조
    //따라서 모든 Stat은 StatManager에서 관리하고 그것을 참조하는 방식으로 구현
    //추후 UpGrade 방식이 추가되면 그것 또한 StatManager에서 관리
    //Ex GetSpeed 함수 뒤에 Upgrade 로직 부착
    //</summary>
    public PlayerDataSO playerData;
    
    private Define.Classes classes = Define.Classes.None;
    public Define.Classes Classes { get => classes; set { classes = value; } } 
    
    public PlayerData Pd;

    public StatManager()
    {
        Pd = new PlayerData();
    }

    
    
    //변동 사항이 생길때 마다 호출해주어야함
    public void RefreshData()
    {
        Pd.Id = Classes.ToString();
        Pd.Damage = GetDamage();
        Pd.Health = GetMaxHealth();           //조금 수정될 필요 있음.
        Pd.AtkSpeed = GetAtkSpeed();
        Pd.Speed = GetSpeed();
    }
    
    public float GetMaxHealth() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기값
        return playerData.DataContainer.playerDatas[(int)classes].Health;
    }
    public float GetSpeed() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기값
        return playerData.DataContainer.playerDatas[(int)classes].Speed;
    }
    public float GetDamage() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기값
        return playerData.DataContainer.playerDatas[(int)classes].Damage;
    }
    public float GetAtkSpeed() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기값
        return playerData.DataContainer.playerDatas[(int)classes].AtkSpeed;
    }

    public void Init()              //캐릭터 선택 후 classes가 정해진 후 호출하면 됨 
    {
        playerData = Resources.Load<PlayerDataSO>("Data/PlayerDataSO");
        classes = Define.Classes.Archor;   //임시코드
        RefreshData();
    }
}
