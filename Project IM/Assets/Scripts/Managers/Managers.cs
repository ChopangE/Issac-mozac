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
    private IManager uiManager = new UIManager();
    private IManager mapManager;
    private IManager networkManager;
    
    public static StatManager StatManager { get { return Instance.statManager as StatManager; } }
    public static GameManager GameManager { get { return Instance.gameManager as GameManager; } }
    public static DataManager DataManager { get { return Instance.dataManager as DataManager; } }
    public static ResourceManager ResourceManager { get { return Instance.resourceManager as ResourceManager; } }
    public static PoolManager PoolManager { get { return Instance.poolManager as PoolManager; } }
    public static SceneManager_ SceneManager { get { return Instance.sceneManager as SceneManager_; } }
    public static UIManager UIManager { get { return Instance.uiManager as UIManager; } }
    public static MapManager MapManager { get { return Instance.mapManager as MapManager; } }
    public static NetworkManager NetworkManager { get { return Instance.networkManager as NetworkManager; } }

    
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
        string prefix = "Managers/";    //MonoBehavior를 가진 Manager는 여기서 Create
        InitStatManager();              //statManager Initialize
        InitDataManager();              //DataManager Initialize
        InitPoolManager();              //PoolManager Initialize
        InitSceneManager();             //SceneManager Initialize
        InitUIManager();
        InitMapManager();
        //InitNetworkManager();
    }

    void InitMapManager()
    {
        mapManager = ResourceManager.InstantiatePrefab("Managers/MapManager", transform).GetComponent<IManager>();
        mapManager.Init();
    }

    void InitNetworkManager()
    {
        networkManager = mapManager = ResourceManager.InstantiatePrefab("Managers/NetworkManager", transform).GetComponent<IManager>();
        networkManager.Init();
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

    void InitUIManager()
    {
        uiManager.Init();
    }
    
    
}
