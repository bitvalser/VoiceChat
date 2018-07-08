using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ExitGames.Demos.DemoPunVoice
{
	using Client.Photon.LoadBalancing;


	public class pushtotalk : Photon.MonoBehaviour {

		private PhotonVoiceRecorder rec;
       

        private void Awake()
        {
            DontDestroyOnLoad(gameObject.transform);
        }
        
        void Start () {
			rec = GetComponent<PhotonVoiceRecorder> ();
			rec.Transmit = false;
        }

        public void Update () {
			if (Input.GetKeyDown(KeyCode.Space)) {
                rec.Transmit = true;
            }
			else if (Input.GetKeyUp(KeyCode.Space))
			{
                rec.Transmit = false;
            }
        }
    }
}
