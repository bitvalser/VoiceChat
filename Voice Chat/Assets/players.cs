using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class players : Photon.MonoBehaviour {

		public Text m_Text;//Текст с игроками
		public float Timer = 3f;//Таймер
	//	public NetworkManager NM;
		public GameObject Camera;

		// Use this for initialization
		void Start()
		{
			GetComponent<PhotonView>().RPC("updateName", PhotonTargets.AllBuffered, PhotonNetwork.playerName);//Вызов RPC
			Debug.Log(PhotonNetwork.countOfPlayersOnMaster);//Дебаг кол-ва игроков на сервере
		}
		// Update is called once per frame
		void Update()
		{
			Timer -= Time.deltaTime;//Отсчёт таймера
			if(Timer <= 0f)
			{
				GetComponent<PhotonView>().RPC("updateName", PhotonTargets.AllBuffered, PhotonNetwork.playerName);//Вызов RPC
				Debug.Log(PhotonNetwork.countOfPlayersOnMaster);
				Timer = 3f;
			}
		}

		[PunRPC]
		public void updateName(string name)
		{
			var playerList = new StringBuilder();

			foreach (var player in PhotonNetwork.playerList)
			{
				playerList.Append("Jopka" + "\n");
			}

			m_Text.text = playerList.ToString();
		}

}
