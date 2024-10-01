using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interface;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour, IManager
{
    [SerializeField]
    public AbstractDungeonGenerator dungeonGenerator;
    
    [SerializeField]
    public TilemapVisualizer tilemapVisualizer;

    public StageData stageData = new StageData();
    
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
        RoomFirstDungeonGenerator roomFirstDungeonGenerator = dungeonGenerator as RoomFirstDungeonGenerator;
        if (roomFirstDungeonGenerator == null) return;
        stageData.roomsCenter = roomFirstDungeonGenerator.rooms;
        stageData.roomsFloors = roomFirstDungeonGenerator.floors;
    }

    public Vector2Int SelectRandomStartPositionInStage()
    {
        if (stageData.roomsCenter == null) return Vector2Int.zero;
        Vector2Int randomPos = stageData.roomsCenter[Random.Range(0,stageData.roomsCenter.Count)];
        return randomPos;
    }

    public Vector2Int SelectRandomFloorPositionInStage()
    {
        if (stageData.roomsFloors == null) return Vector2Int.zero;
        Vector2Int[] tmpArray = new Vector2Int[stageData.roomsFloors.Count];
        stageData.roomsFloors.CopyTo(tmpArray);
        Vector2Int randomPos = tmpArray[UnityEngine.Random.Range(0,tmpArray.Length)];
        return randomPos;
    }
    public Vector2Int SelectBossRoom(List<Vector2Int> rooms,Vector2Int startPos)
    {
        float farDistance = 0;
        Vector2Int farPos = startPos;
        foreach (var room in rooms)
        {
            float currentDistance = Vector2Int.Distance(room, startPos);
            if (currentDistance > farDistance)
            {
                farDistance = currentDistance;
                farPos = room;
            }
        }
        return farPos;
    }
    
    public class StageData
    {
        public List<Vector2Int> roomsCenter;
        public HashSet<Vector2Int> roomsFloors;
        public Vector2Int startPosition;
        public Vector2Int bossPosition;
        
    }
}
