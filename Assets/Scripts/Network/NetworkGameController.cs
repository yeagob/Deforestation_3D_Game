using Deforestation.Interaction;
using Deforestation.Machine;
using Deforestation.Recolectables;
using Photon.Pun;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Deforestation.Network
{

	public class NetworkGameController : GameController
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Unity Callbacks	
		#endregion

		#region Private Methods
		#endregion

		#region Public Methods
		public void InitializePlayer (HealthSystem health, CharacterController player, Inventory inventory, InteractionSystem interaction, Transform playerFollow)
		{
			_playerHealth = health;
			_player = player;
			_inventory = inventory;
			_interactionSystem = interaction;
			_playerFollow = playerFollow;
		}

		public void InitializeMachine( Transform follow, MachineController machine)
		{
			_machineFollow = follow;
			_machine = machine;
		}

		#endregion

	}

}