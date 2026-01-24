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

    }


	public class TaskDetailModel : ITaskDetailModel
	{
		Data.ITaskData _testData = null;
		public TaskDetailModel(Data.ITaskData data)
		{
			_testData = data;

		}

        public ITaskData GetData => _testData;
    }
}