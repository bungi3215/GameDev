using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : Photon.PunBehaviour {

	#region Variables
	public GameObject playerPrefab;

	static public MultiplayerManager instance;
	#endregion

	#region Unity Methods
	private void Start()
	{
		instance = this;

		if(playerPrefab == null)
		{
			Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
			return;
		}



	}
	#endregion

	#region Photon Overrides

	public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
	{
		//Not seen if you are the player connecting
		Debug.Log("MultiplayerManager: Player connected: " + newPlayer.NickName);

		if (PhotonNetwork.isMasterClient)
		{
			Debug.Log("MultiplayerManager: Client is MasterClient");
		}
	}

	public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
	{
		Debug.Log("MultiplayerManager: " + otherPlayer.NickName + " disconnected");
	}

	#endregion

}
