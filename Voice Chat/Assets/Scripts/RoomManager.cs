using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : Photon.MonoBehaviour {
	bool muteALL=false;
    private int players;
    public Text output;
    private string text;
    public Button back;
	public Button mute;
    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("1.0");
        output.text = PhotonNetwork.playerName;
        players = PhotonNetwork.countOfPlayersInRooms;
        back.onClick.AddListener(BackToLobby);
		mute.onClick.AddListener(MuteALL);
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
	public void MuteALL(){
		if (!muteALL) {
			muteALL = true;
			AudioListener.volume = 0.0f;
		} 
		else {
			muteALL = false;
			AudioListener.volume = 1;
		}
	
	}
    void OnJoinedLobby()
    {
    }

    void OnJoinedRoom()
    {
    }
}
