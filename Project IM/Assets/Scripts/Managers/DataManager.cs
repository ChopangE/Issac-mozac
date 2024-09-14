using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening.Plugins.Core.PathCore;
using GameData;
using Interface;
using UnityEngine;
using Path = System.IO.Path;

public class DataManager : IManager
{
    string SavedPath = "/JsonData/PlayerData";
    public void SaveCurrentPlayerData()
    {
        PlayerData playerData = Managers.StatManager.Pd;
        string jsonData = JsonUtility.ToJson(playerData,true);
        string path = Path.Combine(Application.dataPath + SavedPath, "PlayerData.json");
        File.WriteAllText(path, jsonData);
        Debug.Log("Save Success!");
    }
    
    
    public void LoadCurrentPlayerData()
    {
        string path = Path.Combine(Application.dataPath + SavedPath, "PlayerData.json");
        string jsonData = File.ReadAllText(path);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        Managers.StatManager.Pd = playerData;
    }

    public void Init()
    { }
}
