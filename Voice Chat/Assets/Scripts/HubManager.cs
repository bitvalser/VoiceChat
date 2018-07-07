using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubManager : MonoBehaviour {

    public Button create;
    public Button refresh;

    public InputField room_name;

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform);
        create.onClick.AddListener(CreateRoom);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void CreateRoom()
    {
        PhotonNetwork.CreateRoom(room_name.text);
    }

    void OnJoinedLobby()
    {

    }

    void OnJoinedRoom()
    {

    }

    void OnCreatedRoom()
    {

    }
}
