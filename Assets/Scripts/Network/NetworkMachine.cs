
using Deforestation.Machine;
using Photon.Pun;
using UnityEngine;

namespace Deforestation.Network
{
	public class NetworkMachine : MonoBehaviourPun
	{
		#region Fields

		[SerializeField] private MachineController _machine;
		[SerializeField] private Transform _machineFollow;
		private NetworkGameController _gameController;
		#endregion

		#region Properties
		#endregion

		#region Unity Callbacks	
		private void Start()
		{
			_gameController = FindObjectOfType<NetworkGameController>(true);
			if (photonView.IsMine)
			{
				_gameController.InitializeMachine(_machineFollow, _machine);
				_gameController.gameObject.SetActive(true);
			}
			else
			{
				//---
			}
		}
		#endregion

		#region Private Methods
		#endregion

		#region Public Methods
		#endregion

	}

}