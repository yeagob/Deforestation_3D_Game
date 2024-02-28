using UnityEngine;
using System;
namespace Deforestation.Interaction
{
	public enum MachineInteractionType
	{
		Door,
		Stairs,
		Machine
	}
	public class MachineInteraction : MonoBehaviour, IInteractable
	{
		#region Properties
		#endregion

		#region Fields
		[SerializeField] private MachineInteractionType _type;
		[SerializeField] private Transform _target;

		[SerializeField] private InteractableInfo _interactableInfo;


		#endregion

		#region Public Methods
		public InteractableInfo GetInfo()
		{
			_interactableInfo.Type = _type.ToString();
			return _interactableInfo;
		}

		public void Interact()
		{
			if(_type == MachineInteractionType.Door)
			{
				//Move Door
				transform.position = _target.position;
			}
			if (_type == MachineInteractionType.Stairs)
			{
				//Teleport Player
				GameController.Instance.TeleportPlayer(_target.position);
			}
			if (_type == MachineInteractionType.Machine)
			{
				GameController.Instance.MachineMode(true);
			}
		}

		#endregion
	}

}