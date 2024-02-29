
using Deforestation.UI;
using System;
using UnityEngine;
namespace Deforestation.Network
{
	public class UINetwork : MonoBehaviour
	{
		#region Fields
		[SerializeField] private GameObject _connectingPanel;
		[SerializeField] private UIGameController _uIGameController;

		#endregion

		#region Properties
		#endregion

		#region Unity Callbacks	
		#endregion

		#region Private Methods
		#endregion

		#region Public Methods
		public void LoadingComplete()
		{
			_connectingPanel.SetActive(false);
			_uIGameController.enabled = true;
		}
		#endregion

	}
}
