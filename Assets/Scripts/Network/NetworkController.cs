using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Deforestation.Network
{

	public class NetworkController : MonoBehaviourPunCallbacks
	{
		[SerializeField] private UINetwork _ui;
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
			PhotonNetwork.Instantiate("PlayerMultiplayer", new Vector3(1570, 168.98f, 547), Quaternion.identity );
			_ui.LoadingComplete();
		}
	}
}