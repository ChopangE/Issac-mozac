using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;
    public static Managers Instance { get { Init(); return instance; } }


    void Start() {
        Init();
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

}
