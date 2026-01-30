using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TaskSchedulerApp.Game.Presenter
{
	using TaskDetail;

	public interface ITaskDetailPresenter
	{
		
	}

	public class TaskDetailPresenter : ITaskDetailPresenter
	{
		private ITaskDetailView _taskDetailView = null;
		private ITaskDetailModel _taskDetailModel = null;

		public TaskDetailPresenter(ITaskDetailView view,ITaskDetailModel model) 
		{
			_taskDetailView = view ?? throw new ArgumentNullException(nameof(view));
			_taskDetailModel = model ?? throw new ArgumentNullException(nameof(model));
			

			_taskDetailView.Init();
			_taskDetailView.Init(_taskDetailModel.GetData);

			Bind();
		}
		
		private void Bind () 
		{
			_taskDetailView.OnChangeTaskTitle.Subscribe(value =>
			{
				_taskDetailModel.SetTitle = value;
			});

			_taskDetailView.OnChangeTaskDetail.Subscribe(value =>
			{
				_taskDetailModel.SetDetail = value;
			});
		}
	}
}