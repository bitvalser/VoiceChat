using UnityEngine.UI;
using UnityEngine;

public class RoomManager : Photon.MonoBehaviour {

    private int players;
    public Text output;
    private string text;

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("1.0");
        output.text = PhotonNetwork.playerName;
        players = PhotonNetwork.countOfPlayersInRooms;
        
    }

    private void Update()
    {
        
        text = "\n\nSpeakers:\n";
        for (int i = 0; i < PhotonNetwork.room.PlayerCount; i++)
        {
            text += PhotonNetwork.playerList[i].NickName + "\n";
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("\n" + PhotonNetwork.connectionStateDetailed.ToString() + text);
    }

    void OnJoinedLobby()
    {
    }

    void OnJoinedRoom()
    {
    }
}
