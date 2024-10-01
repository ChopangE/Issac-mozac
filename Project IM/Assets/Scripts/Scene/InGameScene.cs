using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using Cinemachine;
using Photon.Pun.Demo.Cockpit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Util;

public class InGameScene : BaseScene
{
    public Player.Player player;
    public PlayerControl playerControl;
    private CinemachineVirtualCamera camera;
    protected override void Init()
    {
        base.Init();
        SceneType = Define.SceneType.InGame;
        camera = FindObjectOfType<CinemachineVirtualCamera>();
        CreateStage();
    }

    public void CreateStage()                          //stage가 바뀔때마다 호출
    {
        if (player != null)
        {
            Managers.ResourceManager.Destroy(player.gameObject);
        }
        string className = SelectCharacter();   //캐릭터 정보
        MapGenerator();                         //맵생성
        SpawnPlayer(className);                 //player생성
        camera.Follow = player.transform;       //카메라 설정
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
        visualizer.floorTilemap = GameObject.FindWithTag("Ground").GetComponent<Tilemap>(); //맵에 Ground tilemap 존재해야함
        visualizer.wallTilemap = GameObject.FindWithTag("Wall").GetComponent<Tilemap>();    //맵에 Wall tilemap 존재해야함
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
        
        Vector2Int randomPos = roomFirstDungeonGenerator.rooms[Random.Range(0,roomFirstDungeonGenerator.rooms.Count)];
        roomFirstDungeonGenerator.rooms.Remove(randomPos);
        
        Managers.MapManager.stageData.startPosition = randomPos;
        Managers.MapManager.stageData.bossPosition = SelectBossRoom(roomFirstDungeonGenerator.rooms, randomPos);
        
        Debug.Log(randomPos.x + " " + randomPos.y);
        Debug.Log( Managers.MapManager.stageData.bossPosition.x + " " +  Managers.MapManager.stageData.bossPosition.y);
        
        go.transform.position = new Vector3(randomPos.x, randomPos.y, 0);
        player = go.GetComponent<Player.Player>();
        playerControl = go.GetComponent<PlayerControl>();
    }

    /// <summary>
    /// x,y좌표가 spawn Point와 가장 먼 곳을 Boss room으로 설정
    /// </summary>
    
    Vector2Int SelectBossRoom(List<Vector2Int> rooms,Vector2Int startPos)
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
    
    public override void Clear()
    {
        Managers.UIManager.CloseAllPages();
    }
}
