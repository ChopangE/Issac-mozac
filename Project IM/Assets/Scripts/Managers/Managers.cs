using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using Util;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    public static Managers Instance { get { Init(); return instance; } }

    private IManager statManager = new StatManager();
    private IManager gameManager;
    private IManager dataManager = new DataManager();
    public static StatManager StatManager { get { return Instance.statManager as StatManager; } }
    public static GameManager GameManager { get { return Instance.gameManager as GameManager; } }
    public static DataManager DataManager { get { return Instance.dataManager as DataManager; } }

    void Awake() {
        Init();
        Create();
    }
    static void Init() {
        if(instance == null) {
            GameObject go = GameObject.Find("@Managers");
            if(go == null) {
                go = new GameObject("@Managers");
                go.AddComponent<Managers>();
            }
            instance = go.GetComponent<Managers>();
            DontDestroyOnLoad(go);
        }
    }
    
    void Create()
    {
        string prefix = "Managers/";
        
        InitStatManager();              //statManager Initialize
    }

    void InitStatManager()
    {
        statManager.Init();
    }
}
