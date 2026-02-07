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
		void ShowDataDetail(ITaskData data);
        IObservable<string> OnChangeTaskTitle { get; }
        IObservable<string> OnChangeTaskDetail { get;}
        IObservable<bool> OnChangeTaskStatus { get; }
        IObservable<Priority> OnChangeTaskPriority { get; }
    }

	[RequireComponent(typeof(ZenjectBinding))]
	public class TaskDetailView : MonoBehaviour ,ITaskDetailView
	{
        [Inject(Id = "ITaskTitleTextComponent")] ITaskTitleTextComponent _taskTitleTextComponent = null;
        
        [Inject(Id = "ITaskDetailTextComponent")]ITaskDetailTextComponent _taskDetailTextComponent = null;

        [Inject(Id = "IStatusToggleComponent")] IStatusToggleComponent _statusToggleComponent = null;

        [Inject(Id = "IPriorityDropdownComponent")] IPriorityDropdownComponent _priorityDropdownComponent = null;

        public IObservable<string> OnChangeTaskDetail => _taskDetailTextComponent.OnEnterText;

        public IObservable<bool> OnChangeTaskStatus => _statusToggleComponent.OnToggleValueChanged;

        public IObservable<Priority> OnChangeTaskPriority => _priorityDropdownComponent.OnSelectPriority;

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

		}

        public void ShowDataDetail(ITaskData data)
        {
            _taskTitleTextComponent.SetText = data.TaskTitle;
            _taskDetailTextComponent.SetText = data.TaskDetail;
            _statusToggleComponent.SetValue = data.TaskStatus;
            _priorityDropdownComponent.SetPriority = data.Priority;
        }

    }
}