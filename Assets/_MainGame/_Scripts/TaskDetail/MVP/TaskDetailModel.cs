using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using TaskSchedulerApp.Data;

namespace TaskSchedulerApp.Game.TaskDetail
{
	public interface ITaskDetailModel
    {
		IObservable<Data.ITaskData> OnChangeSelectedData { get; }

		Data.ITaskData GetData { get; }
		ITaskData SetData { set; }

		string SetTitle { set; }
		string SetDetail { set; }
		bool SetStatus { set; }
		Priority SetPriority { set; }
    }


	public class TaskDetailModel : ITaskDetailModel
	{
		ReactiveProperty<ITaskData> _selectData = new ReactiveProperty<ITaskData>();

		public TaskDetailModel()
		{
		}

        public ITaskData GetData => _selectData.Value;

        public string SetTitle { set => _selectData.Value.TaskTitle = value; }
        public string SetDetail { set => _selectData.Value.TaskDetail = value; }
        public bool SetStatus { set => _selectData.Value.TaskStatus = value; }
        public Priority SetPriority { set => _selectData.Value.Priority = value; }

		public IObservable<ITaskData> OnChangeSelectedData => _selectData;

        public ITaskData SetData { set => _selectData.Value = value; }
    }
}