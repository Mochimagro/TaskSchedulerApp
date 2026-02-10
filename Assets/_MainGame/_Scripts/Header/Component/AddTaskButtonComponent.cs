using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace TaskSchedulerApp.Game.Component
{
	public interface IAddTaskButtonComponent
    {
		void Init();
		IObservable<Unit> OnClickButton { get; }
    }

	[RequireComponent(typeof(ZenjectBinding))]
	public class AddTaskButtonComponent : MonoBehaviour ,IAddTaskButtonComponent
	{
		[SerializeField] Button _addTaskButton;
		Subject<Unit> _onClickButton = new Subject<Unit>();

        public IObservable<Unit> OnClickButton => _onClickButton;

        public void Init () 
		{
			_addTaskButton.OnClickAsObservable().Subscribe(_onClickButton);

		}
		
	}
}