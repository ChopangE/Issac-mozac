using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public PlayerDataSO playerData;
    private Define.Classes classes = Define.Classes.None;
    public Define.Classes Class { get => classes; set { classes = value; } }

    public float GetMaxHealth() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기 값
        return playerData.DataContainer.playerDatas[(int)classes].Health;
    }
    public float GetSpeed() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기 값
        return playerData.DataContainer.playerDatas[(int)classes].Speed;
    }
    public float GetDamage() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기 값
        return playerData.DataContainer.playerDatas[(int)classes].Damage;
    }
    public float GetAtkSpeed() {
        if (playerData.DataContainer.playerDatas == null || classes == Define.Classes.None) return -1.0f;  //쓰레기 값
        return playerData.DataContainer.playerDatas[(int)classes].AtkSpeed;
    }
    
}
