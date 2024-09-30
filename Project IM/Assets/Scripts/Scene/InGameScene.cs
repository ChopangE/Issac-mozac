using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Util;

public class InGameScene : BaseScene
{
    public Player.Player player;
    public PlayerControl playerControl;
    
    protected override void Init()
    {
        base.Init();
        SceneType = Define.SceneType.InGame;
        
        string className = SelectCharacter();
        MapGenerator();
        SpawnPlayer(className);
    }

    string SelectCharacter()
    {
        string className = Managers.StatManager.Classes.ToString();
        //캐릭터 선택창에서 Managers.StatManager.Classes를 선택하고 넘어옴
        if (className == "None") className = Define.Classes.Archer.ToString();  //에러상황 처리
        return className;
    }

    void MapGenerator()
    {
        var visualizer = Managers.MapManager.tilemapVisualizer;
        visualizer.floorTilemap = GameObject.FindWithTag("Ground").GetComponent<Tilemap>();
        visualizer.wallTilemap = GameObject.FindWithTag("Wall").GetComponent<Tilemap>();
        Managers.MapManager.GenerateMap();
    }
    void Start()
    {
        Managers.UIManager.OpenPage<InGameViewModel>();
    }
    void SpawnPlayer(string className)
    {
        GameObject go = Managers.ResourceManager.InstantiatePrefab("Player/" + className);
        RoomFirstDungeonGenerator roomFirstDungeonGenerator = Managers.MapManager.dungeonGenerator as RoomFirstDungeonGenerator;
        Vector2Int randomPos = roomFirstDungeonGenerator.roomCenters[Random.Range(0,roomFirstDungeonGenerator.roomCenters.Count)];
        go.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
        player = FindObjectOfType<Player.Player>();
        playerControl = FindObjectOfType<PlayerControl>();
    }
    public override void Clear()
    {
        Managers.UIManager.CloseAllPages();
    }
}
