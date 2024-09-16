using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/// <summary>
/// Pooling이 필요한 object에 부착.
/// </summary>
public class Poolable : MonoBehaviour
{
    public Define.PrefabType prefabType;
    public bool isUsing;
}
