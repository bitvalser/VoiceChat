using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : Photon.MonoBehaviour {

    private int players;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }


    void OnJoinedLobby()
    {
        //PhotonNetwork.CreateRoom("va", new RoomOptions(), TypedLobby.Default);
        Debug.Log("Lobbi");
    }

    void OnJoinedRoom()
    {
        Debug.Log("Connect");
    }
}
