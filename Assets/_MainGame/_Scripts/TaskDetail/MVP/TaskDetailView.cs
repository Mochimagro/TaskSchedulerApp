using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.UI;
using Zenject;
using TaskSchedulerApp.Game.Component;
using TaskSchedulerApp.Data;

namespace TaskSchedulerApp.Game.TaskDetail
{
	
	public interface ITaskDetailView
    {
		void Init();
		void Init(Data.ITaskData sample);
        IObservable<string> OnChangeTaskTitle { get; }
        IObservable<string> OnChangeTaskDetail { get;}
    }

	[RequireComponent(typeof(ZenjectBinding))]
	public class TaskDetailView : MonoBehaviour ,ITaskDetailView
	{
        [Inject(Id = "ITaskTitleTextComponent")] ITaskTitleTextComponent _taskTitleTextComponent = null;
        
        [Inject(Id = "ITaskDetailTextComponent")]ITaskDetailTextComponent _taskDetailTextComponent = null;

        [Inject(Id = "IStatusToggleComponent")] IStatusToggleComponent _statusToggleComponent = null;

        [Inject(Id = "IPriorityDropdownComponent")] IPriorityDropdownComponent _priorityDropdownComponent = null;

        public IObservable<string> OnChangeTaskDetail => _taskDetailTextComponent.OnEnterText;

        IObservable<string> ITaskDetailView.OnChangeTaskTitle => _taskTitleTextComponent.OnTextEnter;



        public void Init()
		{
            _taskDetailTextComponent.Init();
            _statusToggleComponent.Init();
            _priorityDropdownComponent.Init();
            _taskTitleTextComponent.Init();

            _priorityDropdownComponent.OnSelectPriority.Subscribe(value =>
            {
                Debug.Log($"dropdown changed : {value}");
            });

            _statusToggleComponent.OnToggleValueChanged.Subscribe(value =>
            {
                Debug.Log($"toggle changed : {value}");
            });

		}

        public void Init(ITaskData sample)
        {
            _taskTitleTextComponent.SetText = sample.TaskTitle;
            _taskDetailTextComponent.SetText = sample.TaskDetail;
            _statusToggleComponent.SetValue = sample.IsDone;
            _priorityDropdownComponent.SetPriority = sample.Priority;
        }

    }
}