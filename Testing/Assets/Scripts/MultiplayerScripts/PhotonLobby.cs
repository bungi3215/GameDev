using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : Photon.PunBehaviour {

	#region Public Variables

	public PhotonLogLevel logLevel = PhotonLogLevel.Informational;

	public byte maxPlayersPerRoom = 4;

	#endregion

	#region Private Variables

	string gameVersion = "1";
	bool isConnecting;

	#endregion

	#region MonoBehaviour Callbacks

	private void Awake()
	{
		PhotonNetwork.logLevel = logLevel;
		PhotonNetwork.autoJoinLobby = false;

		PhotonNetwork.automaticallySyncScene = false;
	}

	private void Start()
	{
		Connect();
	}

	#endregion

	#region Public Methods
	public void Connect()
	{
		// keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
		isConnecting = true;

		//We check if we are connected or not, we join if we are, else we initiate the connection to the server
		if (PhotonNetwork.connected)
		{
			PhotonNetwork.JoinRandomRoom();
		}
		else
		{
			//Connect to Photon Online server first
			PhotonNetwork.ConnectUsingSettings(gameVersion);
		}

	}

	public void CreateRoom()
	{
		Debug.Log("Lobby: Creating room without name");

		PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
	}

	public void CreateRoom(string roomName)
	{
		Debug.Log("Lobby: Creating room with name: " + roomName);

		PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
	}

	#endregion

	#region Photon pun behaviour callbacks
	public override void OnConnectedToMaster()
	{
		Debug.Log("Lobby: OnConnectedToMaster was called by PUN");

		//Check if we are attempting to connect
		//Otherwise we could loop

		if (isConnecting)
		{
			//Try to join an existing room. If none is available, OnPhotonRandomJoinFailed() is called
			PhotonNetwork.JoinRandomRoom();
		}
	}

	public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
	{
		Debug.Log("Lobby: OnPhotonRandomJoinFailed was called by PUN. No random room available.");
		CreateRoom();
	}



	public override void OnDisconnectedFromPhoton()
	{
		Debug.Log("Lobby: Disconnected from Photon");
	}

	#endregion


}
