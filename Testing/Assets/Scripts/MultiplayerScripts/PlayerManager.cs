using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Photon.PunBehaviour, IPunObservable
{
	#region Variables
	[Tooltip("The local player instance. Use this to know if the local player is represented in the scene")]
	public static GameObject localPlayerInstance;

	#endregion

	#region Monobehaviour
	private void Awake()
	{
		if (photonView.isMine)
		{
			PlayerManager.localPlayerInstance = this.gameObject;
		}
	}

	void CalledOnLevelWasLoaded(int level)
	{
		if(Physics.Raycast(transform.position, -Vector3.up, 15f))
		{
			transform.position = new Vector3(20f, 0f, 0f);
		}

	}

	#endregion


	void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		
	}
}
