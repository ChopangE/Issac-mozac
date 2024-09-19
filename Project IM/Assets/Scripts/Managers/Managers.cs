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
    private IManager resourceManager = new ResourceManager();
    private IManager poolManager = new PoolManager();
    private IManager sceneManager = new SceneManager_();
    public static StatManager StatManager { get { return Instance.statManager as StatManager; } }
    public static GameManager GameManager { get { return Instance.gameManager as GameManager; } }
    public static DataManager DataManager { get { return Instance.dataManager as DataManager; } }
    public static ResourceManager ResourceManager { get { return Instance.resourceManager as ResourceManager; } }
    public static PoolManager PoolManager { get { return Instance.poolManager as PoolManager; } }
    public static SceneManager_ SceneManager { get { return Instance.sceneManager as SceneManager_; } }

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(SceneManager.CurrentScene.gameObject.name);
        }
    }
    void Create()
    {
        string prefix = "Managers/";
        InitStatManager();              //statManager Initialize
        InitDataManager();              //DataManager Initialize
        InitPoolManager();              //PoolManager Initialize
        InitSceneManager();             //SceneManager Initialize
    }

    void InitDataManager()
    {
        dataManager.Init();
    }

    void InitStatManager()
    {
        statManager.Init();
    }

    void InitPoolManager()
    {
        poolManager.Init();
    }

    void InitSceneManager()
    {
        sceneManager.Init();
    }
}
