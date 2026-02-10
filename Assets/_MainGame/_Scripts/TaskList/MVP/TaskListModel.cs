using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using TaskSchedulerApp.Data;

namespace TaskSchedulerApp.Game.TaskList
{
	public interface ITaskListModel
    {
		List<TaskNameItem> GetTaskList { get; }
		void SetSelectTask(int id);
		IObservable<Unit> OnChangedTaskListData { get; }
    }


	public class TaskListModel : ITaskListModel
	{
		ITaskListData _taskListData = null;
		Subject<Unit> _onChangedTaskListData = new Subject<Unit>();


		public TaskListModel(ITaskListData taskListData)
		{
			_taskListData = taskListData;
			_taskListData.OnChangeListData.Subscribe(_ =>
			{
				_onChangedTaskListData.OnNext(Unit.Default);
			});
		}

		public List<TaskNameItem> GetTaskList => _taskListData.TaskList.Select((data) => new TaskNameItem(data.TaskTitle, data.ID)).ToList();

		public IObservable<Unit> OnChangedTaskListData => _onChangedTaskListData;

        public void SetSelectTask(int id) => _taskListData.SelectData(id);
    }
}