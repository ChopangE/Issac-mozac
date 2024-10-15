using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks, IManager
{
    public GameObject player;
    private void Start()
    {
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect");

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Create!");
        PhotonNetwork.CreateRoom("myRoom", new RoomOptions { MaxPlayers = 4 });
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("Join");
        Vector3 spawonPos = Vector3.zero;

        //PhotonNetwork.Instantiate(player.name, spawonPos, Quaternion.identity);
    }

    public void Init()
    {
        
    }
}
