
using Deforestation.Interaction;
using Deforestation.Recolectables;
using Photon.Pun;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Deforestation
{
	public class NetworkPlayer : MonoBehaviourPun
	{
		#region Fields

		[SerializeField] private HealthSystem _health;
		[SerializeField] private Inventory _inventory;
		[SerializeField] private InteractionSystem _interactions;
		[SerializeField] private CharacterController _controller;
		[SerializeField] private FirstPersonController _fps;
		[SerializeField] private StarterAssetsInputs _inputs;
		[SerializeField] private PlayerInput _inputsPlayer;
		[SerializeField] private GameObject _3dAvatar;
		private GameController _gameController;
		#endregion

		#region Properties
		#endregion

		#region Unity Callbacks	
		private void Start()
		{
			_gameController = FindObjectOfType<GameController>(true);
			if (photonView.IsMine)
			{
				//_gameController.
				_3dAvatar.SetActive(false);
			}
			else
			{
				Destroy(_health);
				Destroy(_inventory);
				Destroy(_interactions);
				Destroy(_controller);
				Destroy(_fps);
				Destroy(_inputs);
				Destroy(_inputsPlayer);
				_3dAvatar.SetActive(true);
			}
		}
		#endregion

		#region Private Methods
		#endregion

		#region Public Methods
		#endregion

	}

}