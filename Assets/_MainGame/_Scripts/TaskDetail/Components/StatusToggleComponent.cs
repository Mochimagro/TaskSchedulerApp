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
		IObservable<bool> OnToggleValueChanged { get; }
    }


	public class StatusToggleComponent : MonoBehaviour ,IStatusToggleComponent
	{
		[SerializeField] Toggle _statusToggle = default;

		Subject<bool> _onToggleValueChanged = new Subject<bool>();
        public IObservable<bool> OnToggleValueChanged => _onToggleValueChanged;


        public bool SetValue { set => _statusToggle.interactable = value; }


        public void Init () 
		{

			_statusToggle.onValueChanged.AddListener((value) =>
			{
				_onToggleValueChanged.OnNext(value);
			});
        }

    }
}