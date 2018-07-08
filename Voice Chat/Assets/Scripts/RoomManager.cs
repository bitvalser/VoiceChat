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
    public Sprite speakerMute;
    public Sprite speakerUnmute;

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
        GUILayout.Label("\n\n\nStatus:\n" + PhotonNetwork.connectionStateDetailed.ToString() + text);
    }

    public void BackToLobby()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("Hub");
    }
	public void MuteALL(){
		if (!muteALL) {
			muteALL = true;
            mute.image.sprite = speakerMute;
            AudioListener.volume = 0.0f;
		} 
		else {
			muteALL = false;
            mute.image.sprite = speakerUnmute;
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
