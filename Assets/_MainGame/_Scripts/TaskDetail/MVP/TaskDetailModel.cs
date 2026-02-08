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
		ITaskData _selectData;

		Subject<Data.ITaskData> _onChangeSelectData = new Subject<Data.ITaskData>();

		public IObservable<ITaskData> OnChangeSelectedData => _onChangeSelectData;

		public TaskDetailModel(Data.ITaskListData taskListData)
		{
			taskListData.OnChangeSelectedData.Subscribe(selected =>
			{
				_selectData = selected;
				_onChangeSelectData.OnNext(_selectData);
			});
		}

        public ITaskData GetData => _selectData;

        public string SetTitle { set => _selectData.TaskTitle = value; }
        public string SetDetail { set => _selectData.TaskDetail = value; }
        public bool SetStatus { set => _selectData.TaskStatus = value; }
        public Priority SetPriority { set => _selectData.Priority = value; }


        public ITaskData SetData { set => _selectData = value; }
    }
}