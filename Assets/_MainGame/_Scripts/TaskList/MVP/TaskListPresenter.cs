using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TaskSchedulerApp.Game.Presenter
{
	using TaskList;
    using TaskSchedulerApp.Data;

    public interface ITaskListPresenter
	{
	}

	public class TaskListPresenter : ITaskListPresenter
	{
		private ITaskListView _taskListView = null;
		private ITaskListModel _taskListModel = null;

		public TaskListPresenter(ITaskListView view,ITaskListModel model) 
		{
			_taskListView = view ?? throw new ArgumentNullException(nameof(view));
			_taskListModel = model ?? throw new ArgumentNullException(nameof(model));
			

			_taskListView.Init();
			Bind();
		}

        private void Bind () 
		{
			_taskListView.CreateTaskItems(_taskListModel.GetTaskList);
			_taskListView.OnSelectTask.Subscribe(id =>
			{
				_taskListModel.SetSelectTask(id);
			});

			_taskListModel.OnChangedTaskListData.Subscribe(_ =>
			{
				_taskListView.RefreshTaskItems(_taskListModel.GetTaskList);
			});
		}
	}
}