using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HubManager : MonoBehaviour {

    public Button create;
    public Button refresh;

    public InputField room_name;

    private List<GameObject> rooms;
    public GameObject roomPrefab;
    public GameObject roomsArea;

    private static string roomNameJoin;

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform);
    }

    private void Start()
    {       
        PhotonNetwork.ConnectUsingSettings("1.0");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.playerName = GameObject.FindWithTag("Nick").GetComponent<TextLine>().getNick();
        refresh.onClick.AddListener(ResfreshRooms);
        create.onClick.AddListener(CreateRoom);
        rooms = new List<GameObject>();
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void CreateRoom()
    {
        if (room_name.text.Length > 0)
        {
            roomNameJoin = room_name.text;
            PhotonNetwork.CreateRoom(room_name.text, new RoomOptions(), TypedLobby.Default);
        }
    }

    void ResfreshRooms()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            Destroy(rooms[i]);
        }
        rooms.Clear();
        RoomsUpdate();
    }

    void RoomsUpdate()
    {
        for (int i = 0; i < PhotonNetwork.GetRoomList().Length; i++)
        {
            GameObject newroom = Instantiate(roomPrefab, roomsArea.transform);
            newroom.transform.localPosition = new Vector3(0, 260 - 44 * i, 0);
            newroom.transform.Find("Text").GetComponent<Text>().text = PhotonNetwork.GetRoomList()[i].Name;
            newroom.transform.Find("count_player").GetComponent<Text>().text = PhotonNetwork.GetRoomList()[i].PlayerCount.ToString();
            newroom.transform.Find("joim").GetComponent<Button>().onClick.AddListener(delegate { JoinRoom(newroom.transform.Find("joim").GetComponent<Button>().gameObject); });

            rooms.Add(newroom);
        }
    }

    void JoinRoom(GameObject join)
    {
        roomNameJoin = join.transform.parent.transform.Find("Text").GetComponent<Text>().text;
        PhotonNetwork.JoinRoom(roomNameJoin);
    }

    public string getCurrenRoomName()
    {
        return roomNameJoin;
    }

    void OnJoinedLobby()
    {

    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("testPrefab", Vector3.zero, Quaternion.identity, 0);
         SceneManager.LoadScene("test");       
    }

    void OnCreatedRoom()
    {
        PhotonNetwork.Instantiate("testPrefab", Vector3.zero, Quaternion.identity, 0);
    }
}
