using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.UI;
using Zenject;
using TaskSchedulerApp.Game.Component;

namespace TaskSchedulerApp.Game.Header
{
	
	public interface IHeaderView
    {
		void Init();
		IObservable<Unit> OnClickAddTask { get; }
	}

	[RequireComponent(typeof(ZenjectBinding))]
	public class HeaderView : MonoBehaviour ,IHeaderView
	{
		[Inject(Id = "IAddTaskButtonComponent")] IAddTaskButtonComponent _addTaskButtonComponent;

        public IObservable<Unit> OnClickAddTask => _onClickAddTask;
		Subject<Unit> _onClickAddTask = new Subject<Unit>();

        public void Init()
		{
			_addTaskButtonComponent.Init();
			_addTaskButtonComponent.OnClickButton.Subscribe(_ =>
			{
				_onClickAddTask.OnNext(Unit.Default);
			});

		}
		
	}
}