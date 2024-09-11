using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public PlayerDataSO PDS;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var v in PDS.DataContainer.playerDatas) {
            Debug.Log(v.Id + " " + v.Damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
