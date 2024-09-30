using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour, IManager
{
    [SerializeField]
    public AbstractDungeonGenerator dungeonGenerator;
    
    [SerializeField]
    public TilemapVisualizer tilemapVisualizer;
    
    
    public void Init()
    {
        GameObject go = Managers.ResourceManager.InstantiatePrefab("Managers/MapManagers/MapGenerator",transform);
        if(go== null) return;
        dungeonGenerator = go.GetComponent<AbstractDungeonGenerator>();
        tilemapVisualizer = Managers.ResourceManager.InstantiatePrefab("Managers/MapManagers/MapVisualizer",transform).GetComponent<TilemapVisualizer>();
        dungeonGenerator.tilemapVisualizer = tilemapVisualizer;
    }
    
    
    public void GenerateMap()
    {
        dungeonGenerator.GenerateDungeon();
    }
}
