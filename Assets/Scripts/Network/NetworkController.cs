using Deforestation.UI;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Deforestation.Network
{

	public class NetworkController : MonoBehaviourPunCallbacks
	{
		[SerializeField] private UINetwork _ui;
		[SerializeField] private UIGameController _uIGameController;

		//Master
		[SerializeField] private List <Transform> _spawnPoints; // Arreglo de tus puntos de spawn.
		private bool _waitingForSpawn = false;

		void Start()
		{
			PhotonNetwork.ConnectUsingSettings();
		}

		public override void OnConnectedToMaster()
		{
			PhotonNetwork.JoinOrCreateRoom("DeforestationRoom", new RoomOptions { MaxPlayers = 10 }, null);
		}

		public override void OnJoinedRoom()
		{
			if (PhotonNetwork.IsMasterClient)
			{				
				SpawnMe(_spawnPoints[0].position);
				_spawnPoints.RemoveAt(0);
			}
			else
			{
				_waitingForSpawn = true;
				photonView.RPC("RPC_SpawnPoint", RpcTarget.MasterClient);

			}
			
			_ui.LoadingComplete();
		}

		private void SpawnMe(Vector3 spawnPoint)
		{
			PhotonNetwork.Instantiate("PlayerMultiplayer", spawnPoint, Quaternion.identity);
			PhotonNetwork.Instantiate("TheMachine", spawnPoint + Vector3.back * 7, Quaternion.identity);
			_uIGameController.enabled = true;
		}

		[PunRPC]
		void RPC_SpawnPoint()
		{			
			photonView.RPC("RPC_RecivePont", RpcTarget.Others, _spawnPoints[0].position);
			_spawnPoints.RemoveAt(0);
		}

		[PunRPC]
		void RPC_RecivePont(Vector3 spawnPos)
		{
			if (_waitingForSpawn)
			{
				_waitingForSpawn = false;
				SpawnMe(spawnPos);
			}
		}
	}
}