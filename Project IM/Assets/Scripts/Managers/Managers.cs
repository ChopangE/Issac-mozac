using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    public static Managers Instance { get { Init(); return instance; } }


    private StatManager statManager;
    private GameManager gameManager;
    public static StatManager StatManager { get { return Instance.statManager; } }
    public static GameManager GameManager { get { return Instance.gameManager; } }

    void Start() {
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
        if (statManager == null)
        {
            GameObject go = Resources.Load<GameObject>(prefix + "StatManager");
            statManager = go.GetComponent<StatManager>();
            Instantiate(go,gameObject.transform);
        }
        
    }
}
