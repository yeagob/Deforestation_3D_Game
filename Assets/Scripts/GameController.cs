using UnityEngine;
using Deforestation.Machine;
using Deforestation.UI;
using Deforestation.Recolectables;
using Deforestation.Interaction;
using Cinemachine;
using System;

namespace Deforestation
{
	public class GameController : Singleton<GameController>
	{
		#region Properties
		public MachineController MachineController => _machine;
		public Inventory Inventory => _inventory;
		public InteractionSystem InteractionSystem => _interactionSystem;
		public TreeTerrainController TerrainController => _terrainController;
		public Camera MainCamera;

		//Events
		public Action<bool> OnMachineModeChange;

		public bool MachineModeOn
		{
			get
			{
				return _machineModeOn;
			}
			private set 
			{
				_machineModeOn = value;
				OnMachineModeChange?.Invoke(_machineModeOn);
			}
		}
		#endregion

		#region Fields
		[Header("Player")]
		[SerializeField] private CharacterController _player;
		[SerializeField] private HealthSystem _playerHealth;
		[SerializeField] private Inventory _inventory;
		[SerializeField] private InteractionSystem _interactionSystem;

		[Header("Camera")]
		[SerializeField] private CinemachineVirtualCamera _virtualCamera;
		[SerializeField] private Transform _playerFollow;
		[SerializeField] private Transform _machineFollow;

		[Header("Machine")]
		[SerializeField] private MachineController _machine;
		[Header("UI")]
		[SerializeField] private UIGameController _uiController;
		[Header("Trees Terrain")]
		[SerializeField] private TreeTerrainController _terrainController;

		private bool _machineModeOn;
		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Start()
		{
			//UI Update
			_playerHealth.OnHealthChanged += _uiController.UpdatePlayerHealth;
			_machine.HealthSystem.OnHealthChanged += _uiController.UpdateMachineHealth;
			MachineModeOn = false;

		}

		// Update is called once per frame
		void Update()
		{

		}
		#endregion

		#region Public Methods
		public void TeleportPlayer(Vector3 target)
		{			
			_player.enabled = false;
			_player.transform.position = target;
			_player.enabled = true;
		}

		internal void MachineMode(bool machineMode)
		{
			MachineModeOn = machineMode;
			//Player
			_player.gameObject.SetActive(!machineMode);
			_player.enabled = !machineMode;

			//Cursor + UI
			if (machineMode)
			{
				//Start Driving
				if ( Inventory.HasResource(RecolectableType.HyperCrystal))
					_machine.StartDriving(machineMode);

				_player.transform.parent = _machineFollow;
				_uiController.HideInteraction();
				Cursor.lockState = CursorLockMode.None;
				//Camera
				_virtualCamera.Follow = _machineFollow;
			}
			else
			{
				_player.transform.parent = null;

				//Camera
				_virtualCamera.Follow = _playerFollow;
				Cursor.lockState = CursorLockMode.Locked;
			}
			Cursor.visible = machineMode;
		}
		#endregion

		#region Private Methods
		#endregion
	}

}