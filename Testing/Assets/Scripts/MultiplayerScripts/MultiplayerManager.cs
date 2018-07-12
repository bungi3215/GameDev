using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : Photon.PunBehaviour
{

	#region Variables
	public GameObject playerPrefab;
	public GameObject playerCamera;

	static public MultiplayerManager instance;
	#endregion

	#region Unity Methods
	private void Start()
	{
		instance = this;

		if (playerPrefab == null)
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

	public override void OnJoinedRoom()
	{
		Debug.Log("MultiplayerManager: Joined a room");


		if (PlayerManager.localPlayerInstance == null)
		{
			Debug.Log("MultiplayerManager: Instantiating player prefab");
			GameObject gameObject = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
			GameObject camera = Instantiate(playerCamera, new Vector3(), Quaternion.identity);
			camera.transform.parent = gameObject.transform;
			camera.transform.localPosition = new Vector3(-0.69f, 3.89f, -8.46f);
		}

	}

	#endregion

}
