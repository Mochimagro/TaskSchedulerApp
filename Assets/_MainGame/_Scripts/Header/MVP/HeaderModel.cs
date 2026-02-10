using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace TaskSchedulerApp.Game.Header
{
	public interface IHeaderModel
    {
		void CreateNewTask();

    }


	public class HeaderModel : IHeaderModel
	{

		Data.ITaskListData _taskListData;

		public HeaderModel(Data.ITaskListData taskListData)
		{
			_taskListData = taskListData;

		}

        public void CreateNewTask()
        {
			_taskListData.CreateNewData();
        }
    }
}