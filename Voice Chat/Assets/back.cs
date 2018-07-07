using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class back : MonoBehaviour {
	public Button backB;


	void Start () {
		backB.onClick.AddListener (Back);
	}
	
	// Update is called once per frame
	void Back () {
		Application.LoadLevel("Hub");
	}
}
