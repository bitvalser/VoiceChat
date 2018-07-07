using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectContoroll : Photon.MonoBehaviour
{
    void Start()
    {
        //PhotonNetwork.ConnectUsingSettings("1.0");
    }
    void OnJoinedLobby()
    {
        //PhotonNetwork.JoinRoom(GameObject.FindWithTag("Hub").GetComponent<HubManager>().getCurrenRoomName());
        //Debug.Log(GameObject.FindWithTag("Hub").GetComponent<HubManager>().getCurrenRoomName());

    }
    void OnJoinedRoom()
    {

    }
}
