using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class ResourceManager : IManager
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject InstantiatePrefab(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>("Prefabs/" + path);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab " + path + " could not be loaded");
            return null;
        }
        GameObject go = GameObject.Instantiate(prefab, parent);
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null) return;
        Object.Destroy(go);
    }

    public void Init()
    { }
}
