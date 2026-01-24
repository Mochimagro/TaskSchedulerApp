using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace TaskSchedulerApp.Game.Component
{
	public interface IStatusToggleComponent
    {
		void Init();
		bool SetValue { set; }
		void OnValueChanged(bool value);
    }


	public class StatusToggleComponent : MonoBehaviour ,IStatusToggleComponent
	{
		[SerializeField] Toggle _statusToggle = default;

        public bool SetValue { set => _statusToggle.interactable = value; }
		

        public void Init () 
		{

        }

		public void OnValueChanged(bool value) => _statusToggle.onValueChanged.AddListener(OnValueChanged);
    }
}