using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Connected");
        PhotonNetwork.Instantiate("testPrefab", Vector3.zero, Quaternion.identity, 0);
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
