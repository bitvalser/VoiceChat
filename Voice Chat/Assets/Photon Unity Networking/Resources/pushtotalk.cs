using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExitGames.Demos.DemoPunVoice
{
	using Client.Photon.LoadBalancing;


	public class pushtotalk : Photon.MonoBehaviour {

		private PhotonVoiceRecorder rec;
        public Sprite NoVoice;
        public Sprite Voice;
        public Button btnVoice;
        private bool isPress;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject.transform);
        }
        // Use this for initialization
        void Start () {
			rec = GetComponent<PhotonVoiceRecorder> ();
			rec.Transmit = false;
            isPress = false;
        }

        public void Update () {
            
			if (Input.GetKeyDown(KeyCode.Space) || isPress) {
				rec.Transmit = true;
            }
			else if (Input.GetKeyUp(KeyCode.Space))
			{
				rec.Transmit = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                btnVoice.image.sprite = Voice;
            }
            else
            {
                btnVoice.image.sprite = NoVoice;
            }
        }

        public void OnPointerDown()
        {
            isPress = true;
            btnVoice.image.sprite = Voice;
        }
        public void onPointerUp()
        {
            isPress = false;
            btnVoice.image.sprite = NoVoice;
        }
    }
}
