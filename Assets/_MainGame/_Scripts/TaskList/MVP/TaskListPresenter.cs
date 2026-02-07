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
		IObservable<ITaskData> OnSelectTaskData {  get; }	
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

        public IObservable<ITaskData> OnSelectTaskData => throw new NotImplementedException();
		Subject<ITaskData> _onSelectTask = new Subject<ITaskData>();
        private void Bind () 
		{
			_taskListView.CreateTaskItems(_taskListModel.GetTaskList);
			_taskListView.OnSelectTask.Subscribe(id =>
			{
				var select = _taskListModel.GetTaskData(id);
				_onSelectTask.OnNext(select);
				// 疎結合にするなら、Modelに「SelectData」を変更して、
				// TaskDetailModelに「SelectData」が変更されたことを感知させて
				// その内容を表示するのが正しいけど、今回は実装速度優先にする
			});
		}
	}
}