using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : Photon.MonoBehaviour {

    private int players;
    public Text output;
    private string text;
    public Button back;

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("1.0");
        output.text = PhotonNetwork.playerName;
        players = PhotonNetwork.countOfPlayersInRooms;
        back.onClick.AddListener(BackToLobby);
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

    public void BackToLobby()
    {
        SceneManager.LoadScene("Hub");
    }

    void OnJoinedLobby()
    {
    }

    void OnJoinedRoom()
    {
    }
}
