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
		Data.ITaskData GetData { get; }
		string SetTitle { set; }
		string SetDetail { set; }
		bool SetStatus { set; }
		Priority SetPriority { set; }
    }


	public class TaskDetailModel : ITaskDetailModel
	{
		Data.ITaskData _testData = null;
		public TaskDetailModel(Data.ITaskData data)
		{
			_testData = data;

		}

        public ITaskData GetData => _testData;

        public string SetTitle { set => _testData.TaskTitle = value; }
        public string SetDetail { set => _testData.TaskDetail = value; }
        public bool SetStatus { set => _testData.TaskStatus = value; }
        public Priority SetPriority { set => _testData.Priority = value; }
    }
}