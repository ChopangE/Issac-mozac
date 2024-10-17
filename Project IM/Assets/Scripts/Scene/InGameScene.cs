using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using Cinemachine;
using Photon.Pun;
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
        //MapGenerator();                         //맵생성
        //SpawnPlayer(className);                //player생성
        SpawnNetworkPlayer(className);          //networkPlayer생성
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
        if(visualizer == null) return;
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
        Managers.MapManager.stageData.startPosition = Managers.MapManager.SelectRandomStartPositionInStage();    //StartPosition 생성
        Managers.MapManager.stageData.bossPosition =                        //BossPosition 생성
            Managers.MapManager.
                SelectBossRoom(Managers.MapManager.stageData.roomsCenter, Managers.MapManager.stageData.startPosition);
        
        Debug.Log(Managers.MapManager.stageData.startPosition.x + " " + Managers.MapManager.stageData.startPosition.y);
        Debug.Log( Managers.MapManager.stageData.bossPosition.x + " " +  Managers.MapManager.stageData.bossPosition.y);
        go.transform.position = new Vector3(Managers.MapManager.stageData.startPosition.x, Managers.MapManager.stageData.startPosition.y, 0);
        player = go.GetComponent<Player.Player>();
        playerControl = go.GetComponent<PlayerControl>();
    }

    void SpawnNetworkPlayer(string className)
    {
        //Managers.MapManager.stageData.startPosition = Managers.MapManager.SelectRandomStartPositionInStage();    //StartPosition 생성
        //Vector3 spawnPos = new Vector3(Managers.MapManager.stageData.startPosition.x, Managers.MapManager.stageData.startPosition.y, 0);
        Vector3 spawnPos = Vector3.zero;
        GameObject go = PhotonNetwork.Instantiate(className, spawnPos, Quaternion.identity);
        player = go.GetComponent<Player.Player>();
        playerControl = go.GetComponent<PlayerControl>();
    }
    /// <summary>
    /// x,y좌표가 spawn Point와 가장 먼 곳을 Boss room으로 설정
    /// </summary>
    
    
    public override void Clear()
    {
        Managers.PoolManager.Clear();
        Managers.UIManager.CloseAllPages();
    }
}
