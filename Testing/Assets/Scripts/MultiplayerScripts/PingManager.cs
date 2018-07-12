using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingManager : Photon.MonoBehaviour {

	public Text pingText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		int ping = PhotonNetwork.networkingPeer.RoundTripTime;

		pingText.text = ping.ToString();

	}
}
